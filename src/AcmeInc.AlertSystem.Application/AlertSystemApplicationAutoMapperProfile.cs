using AcmeInc.AlertSystem.Departments;
using AcmeInc.AlertSystem.Departments.Dtos;
using AcmeInc.AlertSystem.Levels;
using AcmeInc.AlertSystem.Levels.Dtos;
using AcmeInc.AlertSystem.Statuses;
using AcmeInc.AlertSystem.Statuses.Dtos;
using AcmeInc.AlertSystem.Messages;
using AcmeInc.AlertSystem.Messages.Dtos;
using AcmeInc.AlertSystem.MessageSources;
using AcmeInc.AlertSystem.MessageSources.Dtos;
using AutoMapper;
using AcmeInc.AlertSystem.Lookup;
using AcmeInc.AlertSystem.Rules;
using AcmeInc.AlertSystem.Rules.Dtos;
using AcmeInc.AlertSystem.Alerts;
using AcmeInc.AlertSystem.Alerts.Dtos;
using System;

namespace AcmeInc.AlertSystem;

public class AlertSystemApplicationAutoMapperProfile : Profile
{
    public AlertSystemApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Department, DepartmentDto>();
        CreateMap<DepartmentCreateDto, Department>(MemberList.Source);
        CreateMap<DepartmentUpdateDto, Department>(MemberList.Source);
        CreateMap<Level, LevelDto>();
        CreateMap<CreateLevelDto, Level>(MemberList.Source);
        CreateMap<UpdateLevelDto, Level>(MemberList.Source);
        CreateMap<Status, StatusDto>();
        CreateMap<CreateStatusDto, Status>(MemberList.Source);
        CreateMap<UpdateStatusDto, Status>(MemberList.Source);
        CreateMap<Message, MessageDto>();
        CreateMap<CreateMessageDto, Message>(MemberList.Source);
        CreateMap<UpdateMessageDto, Message>(MemberList.Source);
        CreateMap<WebhookMessageSource, WebhookMessageSourceDto>();
        CreateMap<CreateWebhookMessageSourceDto, WebhookMessageSource>(MemberList.Source);
        CreateMap<UpdateWebhookMessageSourceDto, WebhookMessageSource>(MemberList.Source);
        CreateMap<Department, LookupDto<Guid>>();
        CreateMap<Message, LookupDto<Guid>>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title));
        CreateMap<WebhookMessageSource, LookupDto<Guid>>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title));
        CreateMap<Status, LookupDto<Guid>>();
        CreateMap<Level, LookupDto<Guid>>();
        CreateMap<MessageNavigation, MessageNavigationDto>();
        CreateMap<EmailMessageSource, EmailMessageSourceDto>();
        CreateMap<EmailMessageSourceCreateDto, EmailMessageSource>(MemberList.Source);
        CreateMap<EmailMessageSourceUpdateDto, EmailMessageSource>(MemberList.Source);
        CreateMap<EmailMessageSource, LookupDto<Guid>>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Username));
        CreateMap<Rule, RuleDto>();
        CreateMap<RuleCreateDto, Rule>(MemberList.Source);
        CreateMap<RuleUpdateDto, Rule>(MemberList.Source);
        CreateMap<Rule, LookupDto<Guid>>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AlertTitle));
        CreateMap<RuleNavigation, RuleNavigationDto>();
        CreateMap<Alert, AlertDto>();
        CreateMap<AlertCreateDto, Alert>(MemberList.Source);
        CreateMap<AlertUpdateDto, Alert>(MemberList.Source);
        CreateMap<AlertNavigation, AlertNavigationDto>();
        CreateMap<Alert, LookupDto<Guid>>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title));

    }
}
