using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Models;

public class Address
{
    [Display(Name = "Stát")]
    public string? Country { get; init; }

    [Display(Name = "Město")]
    public string? City { get; init; }

    [Display(Name = "PSČ")]
    public string? ZipCode { get; init; }

    [Display(Name = "Ulice")]
    public string? Street { get; init; }
}
