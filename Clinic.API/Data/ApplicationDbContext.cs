using Clinic.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) { }

    public DbSet<Doctor> Doctors { get; set; } = null!;
    
    // Обязательно добавь эту строку:
    public DbSet<Specialization> Specializations { get; set; } = null!;
}