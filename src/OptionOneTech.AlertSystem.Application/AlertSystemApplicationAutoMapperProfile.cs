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
        CreateMap<Status, LookupDto<Guid>>();
        CreateMap<Level, LookupDto<Guid>>();
    }
}