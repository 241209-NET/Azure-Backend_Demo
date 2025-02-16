//Data transfer object
using System.ComponentModel.DataAnnotations;
using PetTracker.API.Model;

namespace PetTracker.API.DTO;

public class OwnerInDTO
{
    public required string Name { get; set; }
    public string? Address { get; set; }

    // public Owner DTOToOwner()
    // {
    //     return new Owner{Name = this.Name, Address = this.Address};
    // }
}

public class PetOutDTO
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public DateOnly? Birthday { get; set; }
}

public class NewPetDTO
{
    [Required]
    public string Name { get; set; } = "";
    public string? Type { get; set; }
    public DateOnly? Birthday { get; set; }
}

public class UpdatePetDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = "";
    public string? Type { get; set; }
    public DateOnly? Birthday { get; set; }
}