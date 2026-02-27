using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic.API.Data;
using Clinic.API.Models;

namespace Clinic.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ServiceController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Service>>> GetServices()
    {
        return await _context.Services.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Service>> CreateService(Service service)
    {
        _context.Services.Add(service);
        await _context.SaveChangesAsync();
        return Ok(service);
    }
}