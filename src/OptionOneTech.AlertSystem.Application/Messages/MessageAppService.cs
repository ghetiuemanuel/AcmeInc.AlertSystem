using System;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.Messages.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Messages;


public class MessageAppService : CrudAppService<Message, MessageDto, Guid, PagedAndSortedResultRequestDto, CreateMessageDto, UpdateMessageDto>,
    IMessageAppService
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

}
