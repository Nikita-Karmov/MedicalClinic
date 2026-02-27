using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.API.Models;

[Table("payments")]
public class Payment
{
    [Column("id")]
    public int Id { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; } // Сумма

    [Column("payment_date")]
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    [Column("status")]
    public string Status { get; set; } = "Paid"; // Статус: Оплачено/Ожидание

    // Привязываем оплату к записи на прием
    [Column("appointment_id")]
    public int AppointmentId { get; set; }
    
    [ForeignKey("AppointmentId")]
    public Appointment? Appointment { get; set; }
}