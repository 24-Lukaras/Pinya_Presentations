using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Models;

public class TestingModel
{
    [UIHint("FieldEditor")]
    public int CountryId { get; init; }
    [UIHint("FieldEditor")]
    public int CompanyId { get; init; }
    [UIHint("FieldEditor")]
    public int DepartmentId { get; init; }
}
