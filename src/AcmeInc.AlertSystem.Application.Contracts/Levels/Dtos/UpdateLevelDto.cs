using System;

namespace AcmeInc.AlertSystem.Levels.Dtos;

[Serializable]
public class UpdateLevelDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public bool Active { get; set; }
}