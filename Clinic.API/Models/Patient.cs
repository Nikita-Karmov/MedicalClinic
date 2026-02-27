using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.API.Models;

[Table("patients")]
public class Patient
{
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    public string LastName { get; set; } = null!;

    [Column("phone")]
    public string Phone { get; set; } = null!;

    [Column("birth_date")]
    public DateTime BirthDate { get; set; }

    // Связь: У пациента есть одна медкарта
    public MedicalCard? MedicalCard { get; set; }
}