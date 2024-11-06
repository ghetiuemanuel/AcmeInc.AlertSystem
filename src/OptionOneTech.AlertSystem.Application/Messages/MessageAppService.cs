using System;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.Messages.Dtos;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Lookup;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace OptionOneTech.AlertSystem.Messages;

public class MessageAppService : CrudAppService<Message, MessageDto, Guid, MessageGetListInput, CreateMessageDto, UpdateMessageDto>, IMessageAppService
{
    protected override string GetPolicyName { get; set; } = AlertSystemPermissions.Message.Default;
    protected override string GetListPolicyName { get; set; } = AlertSystemPermissions.Message.Default;
    protected override string CreatePolicyName { get; set; } = AlertSystemPermissions.Message.Create;
    protected override string UpdatePolicyName { get; set; } = AlertSystemPermissions.Message.Update;
    protected override string DeletePolicyName { get; set; } = AlertSystemPermissions.Message.Delete;

    private readonly IMessageRepository _repository;

    public MessageAppService(IMessageRepository repository) : base(repository)
    {
        _repository = repository;
    }
    protected override async Task<IQueryable<Message>> CreateFilteredQueryAsync(MessageGetListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Title.IsNullOrWhiteSpace(), x => x.Title.Contains(input.Title))
            .WhereIf(!input.From.IsNullOrWhiteSpace(), x => x.From.Contains(input.From))
            .WhereIf(input.SourceId != null, x => x.SourceId == input.SourceId)
            .WhereIf(input.SourceType != null, x => x.SourceType == input.SourceType)
            .WhereIf(!input.Body.IsNullOrWhiteSpace(), x => x.Body.Contains(input.Body))
            .WhereIf(input.ProcessedAt != null, x => x.ProcessedAt.Value.Date == input.ProcessedAt.Value.Date);

    }
    public async Task<PagedResultDto<LookupDto<Guid>>> GetLookupAsync(LookupRequestDto input)
    {
        var messages = await _repository.GetLookupListAsync(input.SkipCount, input.MaxResultCount, input.IncludeInActive);

        var totalCount = await _repository.CountAsync(p => p.SourceId != Guid.Empty);

        return new PagedResultDto<LookupDto<Guid>>(
           totalCount,
           ObjectMapper.Map<List<Message>, List<LookupDto<Guid>>>(messages)
        );
    }
    public async Task<PagedResultDto<MessageNavigationDto>> GetNavigationListAsync(MessageGetListInput input)
    {
        var query = await _repository.GetNavigationList();

        query = query
            .WhereIf(!input.From.IsNullOrWhiteSpace(), x => x.Message.From.Contains(input.From))
            .WhereIf(input.SourceId != null, x => x.Message.SourceId == input.SourceId)
            .WhereIf(input.SourceType != null, x => x.Message.SourceType == input.SourceType)
            .WhereIf(!input.Body.IsNullOrWhiteSpace(), x => x.Message.Body.Contains(input.Body))
            .WhereIf(!input.Title.IsNullOrWhiteSpace(), x => x.Message.Title.Contains(input.Title))
            .WhereIf(input.ProcessedAt != null, x => x.Message.ProcessedAt.Value.Date == input.ProcessedAt.Value.Date);

        if (!input.Sorting.IsNullOrWhiteSpace())
        {
            query = query.OrderBy(input.Sorting);
        }
        else
        {
            query = query.OrderBy(x => x.Message.Title);
        }

        var totalCount = await query.CountAsync();

        var messageNavigations = await query
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .ToListAsync();

        return new PagedResultDto<MessageNavigationDto>(
            totalCount,
            ObjectMapper.Map<List<MessageNavigation>, List<MessageNavigationDto>>(messageNavigations)
        );
    }
}


