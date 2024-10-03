using System;

namespace OptionOneTech.AlertSystem.Levels.Dtos;

[Serializable]
public class CreateLevelDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public bool Active { get; set; }
}