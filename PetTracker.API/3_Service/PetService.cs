using AutoMapper;
using PetTracker.API.DTO;
using PetTracker.API.Model;
using PetTracker.API.Repository;

namespace PetTracker.API.Service;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;
    private readonly IMapper _mapper;

    public PetService(IPetRepository petRepository, IMapper mapper)
    {
        _petRepository = petRepository;
        _mapper = mapper;
    } 

    public IEnumerable<PetOutDTO> GetAllPets()
    {
        var petList = _petRepository.GetAllPets();
        List<PetOutDTO> petDTOList = [];

        //Populate petDTOList from the petList and convert each object
        //Logic to convert from Pet => PetDTO and vice versa
        // foreach(var p in petList)
        // {
        //     PetOutDTO petDTO = _mapper.Map<PetOutDTO>(p);
        //     petDTOList.Add(petDTO);
        // }
        petDTOList = _mapper.Map<List<PetOutDTO>>(petList);

        return petDTOList;

    }

    public async Task<Pet> CreateNewPet(Pet newPet)
    {
        return await _petRepository.CreateNewPet(newPet);
    }

    public Pet? GetPetById(int id)
    {
        if(id < 1) return null;
        return _petRepository.GetPetById(id);
    }

    public Pet? DeletePetById(int id)
    {
        var pet = GetPetById(id);
        if(pet is not null) _petRepository.DeletePetById(id);
        return pet;

    }

    public IEnumerable<Pet> GetPetByName(string name)
    {
        if(String.IsNullOrEmpty(name)) return [];
        
        var petList = _petRepository.GetPetByName(name);
        return petList;
    }

}