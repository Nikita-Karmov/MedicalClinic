using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.API.Models;

[Table("services")]
public class Service
{
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    public string Title { get; set; } = null!; // Название (напр: "Первичный осмотр")

    [Column("price")]
    public decimal Price { get; set; } // Цена

    [Column("duration_minutes")]
    public int DurationMinutes { get; set; } // Длительность в минутах
}