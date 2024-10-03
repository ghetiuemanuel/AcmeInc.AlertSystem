using System;

namespace OptionOneTech.AlertSystem.Messages.Dtos;

[Serializable]
public class UpdateMessageDto
{
    public string Title { get; set; }

    public string From { get; set; }

    public Guid SourceId { get; set; }

    public string SourceType { get; set; }

    public string Body { get; set; }
}