using System;
using Volo.Abp.Application.Dtos;

namespace AcmeInc.AlertSystem.Departments.Dtos;

[Serializable]
public class DepartmentGetListInput : PagedAndSortedResultRequestDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? Active { get; set; }
}