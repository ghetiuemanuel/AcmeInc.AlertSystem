using OptionOneTech.AlertSystem.Departments;
using OptionOneTech.AlertSystem.Departments.Dtos;
using OptionOneTech.AlertSystem.Levels;
using OptionOneTech.AlertSystem.Levels.Dtos;
using OptionOneTech.AlertSystem.Statuses;
using OptionOneTech.AlertSystem.Statuses.Dtos;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Messages.Dtos;
using OptionOneTech.AlertSystem.MessageSources;
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using AutoMapper;
using OptionOneTech.AlertSystem.Lookup;
using OptionOneTech.AlertSystem.Rules;
using OptionOneTech.AlertSystem.Rules.Dtos;
using OptionOneTech.AlertSystem.Alerts;
using OptionOneTech.AlertSystem.Alerts.Dtos;
using System;

namespace OptionOneTech.AlertSystem;

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
        CreateMap<Status, LookupDto<Guid>>()
            .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));
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
