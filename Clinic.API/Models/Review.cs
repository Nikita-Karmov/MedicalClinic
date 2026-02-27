using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.API.Models;

[Table("reviews")]
public class Review
{
    [Column("id")]
    public int Id { get; set; }

    [Column("rating")]
    public int Rating { get; set; } // Оценка от 1 до 5

    [Column("comment")]
    public string? Comment { get; set; } // Текст отзыва

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Привязываем к конкретной записи на прием
    [Column("appointment_id")]
    public int AppointmentId { get; set; }
    
    [ForeignKey("AppointmentId")]
    public Appointment? Appointment { get; set; }
}