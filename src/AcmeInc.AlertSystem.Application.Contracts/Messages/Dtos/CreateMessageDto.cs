using System;

namespace AcmeInc.AlertSystem.Messages.Dtos;

[Serializable]
public class CreateMessageDto
{
    public string Title { get; set; }

    public string From { get; set; }

    public Guid SourceId { get; set; }

    public SourceType SourceType { get; set; }

    public string Body { get; set; }

    public DateTime? ProcessedAt { get; set; }
}