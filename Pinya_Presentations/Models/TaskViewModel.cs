using Pinya_Presentations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Models;

public class TaskViewModel
{
    [Display(Name = "Název")]
    [DataType(DataType.Text)]
    public string Title { get; init; }

    [Display(Name = "Stav")]
    [Editors.SingleEditor]
    public int Status{ get; init; }

    [Display(Name = "Dokončeno %")]
    [Editors.Slider]
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

