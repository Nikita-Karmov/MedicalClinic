using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.API.Models;

[Table("cabinets")]
public class Cabinet
{
    [Column("id")]
    public int Id { get; set; }

    [Column("number")]
    public string Number { get; set; } = null!; // Например: "301" или "Кабинет УЗИ"

    [Column("floor")]
    public int Floor { get; set; } // Этаж
}