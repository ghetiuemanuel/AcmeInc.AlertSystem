using System;
using System.ComponentModel.DataAnnotations;

namespace OptionOneTech.AlertSystem.Web.Pages.Levels.Level.ViewModels;

public class CreateLevelViewModel
{
    [Display(Name = "LevelName")]
    public string Name { get; set; }

    [Display(Name = "LevelDescription")]
    public string Description { get; set; }

    [Display(Name = "LevelActive")]
    public bool Active { get; set; }
}
