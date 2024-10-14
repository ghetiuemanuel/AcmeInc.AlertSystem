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
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using OptionOneTech.AlertSystem.MessageSources;

namespace OptionOneTech.AlertSystem.Messages;

public class MessageAppService : CrudAppService<Message, MessageDto, Guid, MessageGetListInput, CreateMessageDto, UpdateMessageDto>, IMessageAppService
{
    protected override string GetPolicyName { get; set; } = AlertSystemPermissions.Message.Default;
    protected override string GetListPolicyName { get; set; } = AlertSystemPermissions.Message.Default;
    protected override string CreatePolicyName { get; set; } = AlertSystemPermissions.Message.Create;
    protected override string UpdatePolicyName { get; set; } = AlertSystemPermissions.Message.Update;
    protected override string DeletePolicyName { get; set; } = AlertSystemPermissions.Message.Delete;

    private readonly IMessageRepository _repository;
    private readonly IWebhookMessageSourceRepository _webhookMessageSourceRepository;

    public MessageAppService(IMessageRepository repository, IWebhookMessageSourceRepository webhookMessageSourceRepository) : base(repository)
    {
        _repository = repository;
        _webhookMessageSourceRepository = webhookMessageSourceRepository;
    }
    protected override async Task<IQueryable<Message>> CreateFilteredQueryAsync(MessageGetListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Title.IsNullOrWhiteSpace(), x => x.Title.Contains(input.Title))
            .WhereIf(!input.From.IsNullOrWhiteSpace(), x => x.From.Contains(input.From))
            .WhereIf(input.SourceId != null, x => x.SourceId == input.SourceId)
            .WhereIf(input.SourceType != null, x => x.SourceType == input.SourceType)
            .WhereIf(!input.Body.IsNullOrWhiteSpace(), x => x.Body.Contains(input.Body));

    }
    public async Task<PagedResultDto<LookupDto<Guid>>> GetLookupAsync(PagedResultRequestDto input)
    {
        var messages = await _repository.GetLookupListAsync(input.SkipCount, input.MaxResultCount);

        var totalCount = await _repository.CountAsync(p => p.SourceId != Guid.Empty);

        return new PagedResultDto<LookupDto<Guid>>(
           totalCount,
           ObjectMapper.Map<List<Message>, List<LookupDto<Guid>>>(messages)
        );
    }
    public async Task<PagedResultDto<MessageNavigationDto>> GetNavigationListAsync(MessageGetListInput input)
    {
        var query = await _repository.GetNavigationList();

        var webhookSources = await _webhookMessageSourceRepository.GetAllAsync();

        var sourceQuery = from messageNavigation in query
                          join webhookSource in webhookSources 
                          on messageNavigation.Message.SourceId equals webhookSource.Id into webhookJoin
                          from webhookSource in webhookJoin.DefaultIfEmpty()
                          select new
                          {
                              messageNavigation,
                              WebhookMessageSource = webhookSource
                          };

        sourceQuery = sourceQuery
            .WhereIf(!input.From.IsNullOrWhiteSpace(), x => x.messageNavigation.Message.From.Contains(input.From))
            .WhereIf(input.SourceId != null, x => x.messageNavigation.Message.SourceId == input.SourceId)
            .WhereIf(input.SourceType != null, x => x.messageNavigation.Message.SourceType == input.SourceType)
            .WhereIf(!input.Body.IsNullOrWhiteSpace(), x => x.messageNavigation.Message.Body.Contains(input.Body))
            .WhereIf(!input.Title.IsNullOrWhiteSpace(), x => x.messageNavigation.Message.Title.Contains(input.Title));

        if (!input.Sorting.IsNullOrWhiteSpace())
        {
            sourceQuery = sourceQuery.OrderBy(input.Sorting);
        }
        else
        {
            sourceQuery = sourceQuery.OrderBy(x => x.messageNavigation.Message.Title);
        }

        var totalCount = await sourceQuery.CountAsync();

        var messageNavigations = await sourceQuery
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .ToListAsync();

        var result = messageNavigations.Select(x => new MessageNavigationDto
        {
            Message = ObjectMapper.Map<Message, MessageDto>(x.messageNavigation.Message),
            WebhookMessageSource = ObjectMapper.Map<WebhookMessageSource, WebhookMessageSourceDto>(x.WebhookMessageSource)
        }).ToList();

        return new PagedResultDto<MessageNavigationDto>(totalCount, result);
    }
}


