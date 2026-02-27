using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.API.Models;

[Table("specializations")] // Имя таблицы в твоей БД
public class Specialization
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;
    public List<Doctor> Doctors { get; set; } = new();
}