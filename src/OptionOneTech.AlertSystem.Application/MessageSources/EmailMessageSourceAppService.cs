using System;
using System.Linq;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using Volo.Abp.Application.Services;
using OptionOneTech.AlertSystem.Lookup;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Security.Encryption;

namespace OptionOneTech.AlertSystem.MessageSources;


public class EmailMessageSourceAppService : CrudAppService<EmailMessageSource, EmailMessageSourceDto, Guid, EmailMessageSourceGetListInput, EmailMessageSourceCreateDto, EmailMessageSourceUpdateDto>,
    IEmailMessageSourceAppService
{
    protected override string GetPolicyName { get; set; } = AlertSystemPermissions.EmailMessageSource.Default;
    protected override string GetListPolicyName { get; set; } = AlertSystemPermissions.EmailMessageSource.Default;
    protected override string CreatePolicyName { get; set; } = AlertSystemPermissions.EmailMessageSource.Create;
    protected override string UpdatePolicyName { get; set; } = AlertSystemPermissions.EmailMessageSource.Update;
    protected override string DeletePolicyName { get; set; } = AlertSystemPermissions.EmailMessageSource.Delete;

    private readonly IEmailMessageSourceRepository _repository;
    private readonly IStringEncryptionService _stringEncryptionService;

    public EmailMessageSourceAppService(IEmailMessageSourceRepository repository, IStringEncryptionService stringEncriptionService) : base(repository)
    {
        _repository = repository;
        _stringEncryptionService = stringEncriptionService;
    }

    protected override async Task<IQueryable<EmailMessageSource>> CreateFilteredQueryAsync(EmailMessageSourceGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Hostname.IsNullOrWhiteSpace(), x => x.Hostname.Contains(input.Hostname))
            .WhereIf(input.Port != null, x => x.Port == input.Port)
            .WhereIf(input.SSL != null, x => x.SSL == input.SSL)
            .WhereIf(!input.Username.IsNullOrWhiteSpace(), x => x.Username.Contains(input.Username))
            .WhereIf(!input.Folder.IsNullOrWhiteSpace(), x => x.Folder.Contains(input.Folder))
            .WhereIf(input.DeleteAfterDownload != null, x => x.DeleteAfterDownload == input.DeleteAfterDownload)
            .WhereIf(input.Active != null, x => x.Active == input.Active)
            ;
    }
    public override Task<EmailMessageSourceDto> CreateAsync(EmailMessageSourceCreateDto input)
    {

        if (input.Password != null)
        {
            input.Password = _stringEncryptionService.Encrypt(input.Password);
        }

        return base.CreateAsync(input);
    }
    public async Task<PagedResultDto<LookupDto<Guid>>> GetLookupAsync(LookupRequestDto input)
    {
        var list = await _repository.GetLookupListAsync(input.SkipCount, input.MaxResultCount, input.IncludeInActive);

        int totalCount;

        if (input.IncludeInActive)
        {
            totalCount = await _repository.CountAsync();
        }
        else
        {
            totalCount = await _repository.CountAsync(p => p.Active);
        }

        return new PagedResultDto<LookupDto<Guid>>(
           totalCount,
           ObjectMapper.Map<List<EmailMessageSource>, List<LookupDto<Guid>>>(list)
        );
    }
}
