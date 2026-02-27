using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.API.Models;

[Table("doctors")]
public class Doctor
{
    [Column("id")]
    public int Id { get; set; }

    [Column("full_name")]
    public string FullName { get; set; } = null!;

    [Column("experience_years")]
    public int ExperienceYears { get; set; }

    [Column("bio")]
    public string? Bio { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; } = false; 

    // 1. Поле для ID (Foreign Key) - это само значение в таблице
    [Column("specialization_id")]
    public int? SpecializationId { get; set; }

    // 2. Навигационное свойство - это объект "Специализация"
    // Мы ставим его в конец, потому что это связь, а не просто колонка
    [ForeignKey("SpecializationId")]
    public Specialization? Specialization { get; set; } 
}