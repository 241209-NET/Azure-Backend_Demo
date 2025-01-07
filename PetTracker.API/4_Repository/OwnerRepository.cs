using Microsoft.EntityFrameworkCore;
using PetTracker.API.Data;
using PetTracker.API.Model;

namespace PetTracker.API.Repository;

public class OwnerRepository : IOwnerRepository
{
    private readonly PetContext _petContext;

    public OwnerRepository(PetContext petContext) => _petContext = petContext;

    public IEnumerable<Owner> GetAllOwners()
    {
        return _petContext.Owners
            .Include(o => o.Pets)
            .ToList();
    }

    public Owner? GetOwnerById(int id)
    {
        return _petContext.Owners
            .Include(o => o.Pets)
            .FirstOrDefault(o => o.Id == id);
    }

    public Owner CreateNewOwner(Owner newOwner)
    {
        _petContext.Owners.Add(newOwner);
        _petContext.SaveChanges();
        return newOwner;
    }

    public Owner DeleteById(Owner deleteOwner)
    {
        //var owner = _petContext.Owners.Find(id);
        _petContext.Owners.Remove(deleteOwner);
        _petContext.SaveChanges();
        return deleteOwner;
    }
}