using System;

namespace OptionOneTech.AlertSystem.Statuses.Dtos;

[Serializable]
public class UpdateStatusDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public bool Active { get; set; }
}