using System;

namespace OptionOneTech.AlertSystem.Departments.Dtos;

[Serializable]
public class DepartmentUpdateDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public bool Active { get; set; }
}