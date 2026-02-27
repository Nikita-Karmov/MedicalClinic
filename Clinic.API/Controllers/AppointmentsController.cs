using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic.API.Data;
using Clinic.API.Models;

namespace Clinic.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AppointmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Получить все записи (с именами врачей и пациентов)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
    {
        return await _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .Include(a => a.Service)
            .ToListAsync();
    }

    // Создать новую запись
    [HttpPost]
    public async Task<ActionResult<Appointment>> CreateAppointment(Appointment appointment)
    {
        // Очищаем навигационные свойства, чтобы EF не пытался создать 
        // новых людей, а просто использовал существующие ID
        appointment.Patient = null;
        appointment.Doctor = null;
        appointment.Service = null;

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
        return Ok(appointment);
    }
}