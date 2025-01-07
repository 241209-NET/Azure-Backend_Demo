using PetTracker.API.DTO;
using PetTracker.API.Model;

namespace PetTracker.API.Service;

public interface IPetService
{
    Task<Pet> CreateNewPet(NewPetDTO newPet);

    IEnumerable<PetOutDTO> GetAllPets();
    Pet? GetPetById(int id);
    IEnumerable<Pet> GetPetByName(string name);

    UpdatePetDTO? UpdatePet(UpdatePetDTO updatePet);

    Pet? DeletePetById(int id);
}

public interface IOwnerService
{
    IEnumerable<Owner> GetAllOwners();
    Owner? GetOwnerById(int id);
    Owner CreateNewOwner(OwnerInDTO newOwner);
    Owner DeleteOwnerById(int id);
}