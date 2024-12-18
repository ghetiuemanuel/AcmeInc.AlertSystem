﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace AcmeInc.AlertSystem.Messages
{
    public class Message : FullAuditedEntity<Guid>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public Guid SourceId { get; set; }

        [Required]
        public SourceType SourceType { get; set; }

        [Required]
        public string Body { get; set; }
        public DateTime? ProcessedAt { get; set; }

    public Message()
    {
    }

    public Message(
        Guid id,
        string title,
        string from,
        Guid sourceId,
        SourceType sourceType,
        string body,
        DateTime? processedAt
    ) : base(id)
    {
        Title = title;
        From = from;
        SourceId = sourceId;
        SourceType = sourceType;
        Body = body;
        ProcessedAt = processedAt; 
    }
    }
}

