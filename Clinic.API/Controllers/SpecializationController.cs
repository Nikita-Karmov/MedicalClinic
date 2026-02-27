using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic.API.Data;
using Clinic.API.Models;

namespace Clinic.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpecializationController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SpecializationController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Specialization (Получить все специализации)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Specialization>>> GetSpecializations()
    {
        return await _context.Specializations.ToListAsync();
    }

    // POST: api/Specialization (Добавить новую специализацию)
    [HttpPost]
    public async Task<ActionResult<Specialization>> CreateSpecialization(Specialization specialization)
    {
        _context.Specializations.Add(specialization);
        await _context.SaveChangesAsync();
        return Ok(specialization);
    }
}