using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.API.Models;

[Table("medical_records")]
public class MedicalCard
{
    [Column("id")]
    public int Id { get; set; }

    [Column("card_number")]
    public string CardNumber { get; set; } = null!; // Номер полиса или карты

    [Column("blood_type")]
    public string? BloodType { get; set; } // Группа крови

    [Column("allergies")]
    public string? Allergies { get; set; } // Аллергии

    // Связь с пациентом
    [Column("patient_id")]
    public int PatientId { get; set; }
    
    [ForeignKey("PatientId")]
    public Patient? Patient { get; set; }
}