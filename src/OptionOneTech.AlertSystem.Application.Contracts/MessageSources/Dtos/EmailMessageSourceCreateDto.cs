using System;

namespace OptionOneTech.AlertSystem.MessageSources.Dtos;

[Serializable]
public class EmailMessageSourceCreateDto
{
    public string Hostname { get; set; }

    public int Port { get; set; }

    public bool SSL { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Folder { get; set; }

    public bool DeleteAfterDownload { get; set; }

    public bool Active { get; set; }
}