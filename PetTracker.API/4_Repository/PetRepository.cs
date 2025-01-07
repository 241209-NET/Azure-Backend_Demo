using Microsoft.EntityFrameworkCore;
using PetTracker.API.Data;
using PetTracker.API.Model;

namespace PetTracker.API.Repository;

public class PetRepository : IPetRepository
{
    //Need the DB Object to work with.
    private readonly PetContext _petContext;

    public PetRepository(PetContext petContext) => _petContext = petContext;


    public async Task<Pet> CreateNewPet(Pet newPet)
    {
        //Insert into Pets Values (newPet)
        await _petContext.Pets.AddAsync(newPet);
        await _petContext.SaveChangesAsync();
        return newPet;
    }

    public IEnumerable<Pet> GetAllPets()
    {
        return _petContext.Pets
            .Include(p => p.Owners)
            .ToList();
    }

    public Pet? GetPetById(int id)
    {
        return _petContext.Pets.Find(id);
    }

    public IEnumerable<Pet> GetPetByName(string name)
    {
       var petList = _petContext.Pets.Where(p => p.Name.Contains(name)).ToList();
       return petList;
    }

    public Pet UpdatePet(Pet updatePet)
    {
        var oldPet = GetPetById(updatePet.Id);
        _petContext.Pets.Entry(oldPet!).CurrentValues.SetValues(updatePet);
        _petContext.SaveChanges();
        return oldPet!;
    }

    public Pet DeletePetById(int id)
    {
        var pet = GetPetById(id);
        _petContext.Pets.Remove(pet!);
        _petContext.SaveChanges();
        return pet!;
    }

    
}