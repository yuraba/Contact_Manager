using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace McLaren.Models;

public class FileModel
{
    [Key]
    [JsonIgnore]
    public int FileId { get; set; }
    public string Name { get; set; }
    public DateTime DateBirth { get; set; }
    public bool Married { get; set; }
    public string Phone { get; set; }
    public decimal Salary { get; set; }
}