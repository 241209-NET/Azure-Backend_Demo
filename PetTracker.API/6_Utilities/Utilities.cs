using PetTracker.API.DTO;
using PetTracker.API.Model;

namespace PetTracker.API.Util;

public static class Utilities
{
    public static Owner DTOToObject(OwnerInDTO ownerDTO)
    {
        return new Owner{Name = ownerDTO.Name, Address = ownerDTO.Address};
    }
}