using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic.API.Data;
using Clinic.API.Models;

namespace Clinic.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PatientsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
    {
        // Подгружаем пациента вместе с его медкартой
        return await _context.Patients.Include(p => p.MedicalCard).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        return Ok(patient);
    }
}