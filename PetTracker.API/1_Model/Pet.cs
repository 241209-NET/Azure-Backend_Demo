
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PetTracker.API.Model;

public class Pet
{
    public int Id { get; set; }
    [MaxLength(5)]
    [DeniedValues("foo","bar","gee")]
    public string Name { get; set; } = "";
    [Required]
    public string? Type { get; set; }
    public DateOnly? Birthday { get; set; }
    
    public List<Owner> Owners { get; set; } = [];
}