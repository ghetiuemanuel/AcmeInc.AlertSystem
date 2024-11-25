using System;

namespace AcmeInc.AlertSystem.Statuses.Dtos;

[Serializable]
public class UpdateStatusDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public bool Active { get; set; }
}