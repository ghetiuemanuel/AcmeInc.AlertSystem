using AcmeInc.AlertSystem.Departments.Dtos;
using AcmeInc.AlertSystem.Web.Pages.Department.ViewModels;
using AcmeInc.AlertSystem.Levels.Dtos;
using AcmeInc.AlertSystem.Web.Pages.Level.ViewModels;
using AcmeInc.AlertSystem.Statuses.Dtos;
using AcmeInc.AlertSystem.Web.Pages.Status.ViewModels;
using AcmeInc.AlertSystem.Messages.Dtos;
using AcmeInc.AlertSystem.Web.Pages.Message.ViewModels;
using AcmeInc.AlertSystem.MessageSources.Dtos;
using AutoMapper;
using AcmeInc.AlertSystem.Web.Pages.WebhookMessageSource.ViewModels;
using AcmeInc.AlertSystem.Rules.Dtos;
using AcmeInc.AlertSystem.Web.Pages.EmailMessageSource.ViewModels;
using AcmeInc.AlertSystem.Alerts.Dtos;
using AcmeInc.AlertSystem.Web.Pages.Alert.ViewModels;
using AcmeInc.AlertSystem.Web.Pages.Rule.ViewModels;

namespace AcmeInc.AlertSystem.Web;

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
        CreateMap<AlertDto, EditAlertViewModel>();
        CreateMap<CreateAlertViewModel, AlertCreateDto>();
        CreateMap<EditAlertViewModel, AlertUpdateDto>();
    }
}
