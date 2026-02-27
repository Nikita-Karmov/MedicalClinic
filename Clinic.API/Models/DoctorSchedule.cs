using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.API.Models;

[Table("doctor_schedules")]
public class DoctorSchedule
{
    [Column("id")]
    public int Id { get; set; }

    [Column("doctor_id")]
    public int DoctorId { get; set; }
    [ForeignKey("DoctorId")]
    public Doctor? Doctor { get; set; }

    [Column("day_of_week")]
    public DayOfWeek DayOfWeek { get; set; }

    [Column("start_time")]
    public TimeSpan StartTime { get; set; }

    [Column("end_time")]
    public TimeSpan EndTime { get; set; }
    
    [Column("cabinet_id")]
    public int CabinetId { get; set; }
    [ForeignKey("CabinetId")]
    public Cabinet? Cabinet { get; set; }
}