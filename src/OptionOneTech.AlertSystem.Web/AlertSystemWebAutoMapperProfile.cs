using OptionOneTech.AlertSystem.Departments.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Department.ViewModels;
using OptionOneTech.AlertSystem.Levels.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Level.ViewModels;
using OptionOneTech.AlertSystem.Statuses.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Status.ViewModels;
using OptionOneTech.AlertSystem.Messages.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Message.ViewModels;
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using AutoMapper;
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.WebhookMessageSource.ViewModels;
using OptionOneTech.AlertSystem.Rules.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.EmailMessageSource.ViewModels;
using OptionOneTech.AlertSystem.Web.Pages.Rule.ViewModels;

namespace OptionOneTech.AlertSystem.Web;

public class AlertSystemWebAutoMapperProfile : Profile
{
    public AlertSystemWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<DepartmentDto, EditDepartmentViewModel>();
        CreateMap<CreateDepartmentViewModel, DepartmentCreateDto>();
        CreateMap<EditDepartmentViewModel, DepartmentUpdateDto>();
        CreateMap<LevelDto, EditLevelViewModel>();
        CreateMap<CreateLevelViewModel, CreateLevelDto>();
        CreateMap<EditLevelViewModel, UpdateLevelDto>();
        CreateMap<StatusDto, EditStatusViewModel>();
        CreateMap<CreateStatusViewModel, CreateStatusDto>();
        CreateMap<EditStatusViewModel, UpdateStatusDto>();
        CreateMap<MessageDto, EditMessageViewModel>();
        CreateMap<CreateMessageViewModel, CreateMessageDto>();
        CreateMap<EditMessageViewModel, UpdateMessageDto>();
        CreateMap<WebhookMessageSourceDto, EditWebhookMessageSourceViewModel>();
        CreateMap<CreateWebhookMessageSourceViewModel, CreateWebhookMessageSourceDto>();
        CreateMap<EditWebhookMessageSourceViewModel, UpdateWebhookMessageSourceDto>();

        CreateMap<EmailMessageSourceDto, EditEmailMessageSourceViewModel>();
        CreateMap<CreateEmailMessageSourceViewModel, EmailMessageSourceCreateDto>();
        CreateMap<EditEmailMessageSourceViewModel, EmailMessageSourceUpdateDto>();
        CreateMap<RuleDto, EditRuleViewModel>();
        CreateMap<CreateRuleViewModel, RuleCreateDto>();
        CreateMap<EditRuleViewModel, RuleUpdateDto>();
    }
}
