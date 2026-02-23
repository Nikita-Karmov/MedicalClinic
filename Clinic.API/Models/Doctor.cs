using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.API.Models;

[Table("doctors")]
public class Doctor
{
    [Column("id")]
    public int Id { get; set; }

    [Column("full_name")]
    public string FullName { get; set; } = null!;

    [Column("specialization_id")]
    public int? SpecializationId { get; set; }

    [Column("experience_years")]
    public int ExperienceYears { get; set; }

    [Column("bio")]
    public string? Bio { get; set; }

    // --- ДОБАВЛЯЕМ СЮДА ---
    [Column("is_deleted")]
    public bool IsDeleted { get; set; } = false; 

    [ForeignKey("SpecializationId")]
    public Specialization? Specialization { get; set; } 
}