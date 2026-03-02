using Pinya_Presentations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Models;

public class TaskViewModel
{
    [Display(Name = "Název")]
    [DataType(DataType.Text)]
    public string Title { get; init; }

    [Display(Name = "Stav")]
    [Editors.EnumDropdown<TaskState>]
    public int Status{ get; init; }

    [Display(Name = "Zdroj")]
    [Editors.EnumDropdown<TaskSource>]
    public int Source { get; init; }

    [Display(Name = "Položka")]
    [Editors.OrderItemsDropdown]
    public int OrderItem { get; init; }

    [Display(Name = "Dokončeno %")]
    [Editors.Slider(Min = 10, Max = 50)]
    public int PercentComplete { get; init; }
}
public enum TaskState
{
    [Display(Name = "Draft")]
    Draft,

    [Display(Name = "Plánováno")]
    Planned,

    [Display(Name = "V plnění")]
    InProgress,

    [Display(Name = "Dokončeno")]
    Complete,
}
public enum TaskSource
{
    [Display(Name = "Zákazník")]
    Customer,
    [Display(Name = "Maintenance")]
    Maintenance,
    [Display(Name = "Bugfix")]
    Bugfix,
}

