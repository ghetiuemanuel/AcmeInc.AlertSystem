using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.Departments.Dtos;

[Serializable]
public class DepartmentGetListInput : PagedAndSortedResultRequestDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? Active { get; set; }
}