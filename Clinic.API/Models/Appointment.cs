using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.API.Models;

[Table("appointments")]
public class Appointment
{
    [Column("id")]
    public int Id { get; set; }

    [Column("patient_id")]
    public int PatientId { get; set; }
    [ForeignKey("PatientId")]
    public Patient? Patient { get; set; }

    [Column("doctor_id")]
    public int DoctorId { get; set; }
    [ForeignKey("DoctorId")]
    public Doctor? Doctor { get; set; }

    [Column("service_id")]
    public int ServiceId { get; set; }
    [ForeignKey("ServiceId")]
    public Service? Service { get; set; }

    [Column("appointment_date")]
    public DateTime AppointmentDate { get; set; }

    [Column("status")]
    public string Status { get; set; } = "Scheduled"; // Запланировано, Завершено, Отменено
}