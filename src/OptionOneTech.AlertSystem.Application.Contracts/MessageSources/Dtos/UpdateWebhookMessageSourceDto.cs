using System;

namespace OptionOneTech.AlertSystem.MessageSources.Dtos;

[Serializable]
public class UpdateWebhookMessageSourceDto
{
    public string Title { get; set; }

    public string From { get; set; }

    public string Body { get; set; }
}