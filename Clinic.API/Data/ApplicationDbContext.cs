using Microsoft.EntityFrameworkCore;
using Clinic.API.Models;

namespace Clinic.API.Data; // Проверь, чтобы неймспейс был твой

public class ApplicationDbContext : DbContext
{
    // ВОТ ЭТОТ КУСОК НУЖНО ДОБАВИТЬ:
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Твои таблицы (DbSet)
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<MedicalCard> MedicalCards { get; set; }
    public DbSet<Cabinet> Cabinets { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }
}