using Clinic.API.Data;
using Clinic.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DoctorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 1. ПОЛУЧИТЬ ТОЛЬКО АКТИВНЫХ ВРАЧЕЙ
    [HttpGet]
    public async Task<IActionResult> GetDoctors()
    {
        var doctors = await _context.Doctors
            .Include(d => d.Specialization)
            .Where(d => !d.IsDeleted) // ИЗМЕНЕНО: Фильтруем, чтобы не видеть "удаленных"
            .ToListAsync();
        return Ok(doctors);
    }

    // 2. ДОБАВИТЬ НОВОГО ВРАЧА (Остается без изменений)
    [HttpPost]
    public async Task<IActionResult> CreateDoctor(Doctor doctor)
    {
        doctor.Specialization = null; 
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDoctors), new { id = doctor.Id }, doctor);
    }

    // 3. ОБНОВИТЬ ДАННЫЕ ВРАЧА (Остается без изменений)
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctor(int id, Doctor doctor)
    {
        if (id != doctor.Id) return BadRequest();
        _context.Entry(doctor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Doctors.Any(e => e.Id == id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // 4. МЯГКОЕ УДАЛЕНИЕ ВРАЧА
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null) return NotFound();

        // ИЗМЕНЕНО: Вместо Remove просто меняем флаг
        doctor.IsDeleted = true; 
        
        await _context.SaveChangesAsync();
        return NoContent(); // Ошибки 500 больше не будет!
    }
    [HttpPost("{id}/restore")]
    public async Task<IActionResult> RestoreDoctor(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null) return NotFound();

        doctor.IsDeleted = false; // Возвращаем в строй!
        await _context.SaveChangesAsync();

        return Ok(new { message = $"Врач {doctor.FullName} успешно восстановлен!" });
    }
}