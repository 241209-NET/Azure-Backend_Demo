using PetTracker.API.Model;

namespace PetTracker.API.Repository;

public interface IPetRepository
{
    //CRUD

    //Create
    Task<Pet> CreateNewPet(Pet newPet); 

    //Read
    IEnumerable<Pet> GetAllPets(); 
    Pet? GetPetById(int id); 
    IEnumerable<Pet> GetPetByName(string name);

    //Update
    Pet UpdatePet(Pet updatePet);

    //Delete
    Pet DeletePetById(int id);    
}

public interface IOwnerRepository
{
    //CRUD
    IEnumerable<Owner> GetAllOwners();
    Owner? GetOwnerById(int id);
    Owner CreateNewOwner(Owner newOwner);
    Owner DeleteById(Owner deleteOwner);    
}