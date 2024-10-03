using System;
using System.ComponentModel.DataAnnotations;

namespace OptionOneTech.AlertSystem.Web.Pages.Levels.Level.ViewModels;

public class EditLevelViewModel
{
    [Display(Name = "LevelName")]
    public string Name { get; set; }

    [Display(Name = "LevelDescription")]
    public string Description { get; set; }

    [Display(Name = "LevelActive")]
    public bool Active { get; set; }
}
