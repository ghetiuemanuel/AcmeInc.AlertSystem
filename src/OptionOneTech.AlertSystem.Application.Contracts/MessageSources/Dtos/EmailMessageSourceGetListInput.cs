using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.MessageSources.Dtos;

[Serializable]
public class EmailMessageSourceGetListInput : PagedAndSortedResultRequestDto
{
    public string? Hostname { get; set; }

    public int? Port { get; set; }

    public bool? SSL { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Folder { get; set; }

    public bool? DeleteAfterDownload { get; set; }

    public bool? Active { get; set; }
}