using AutoMapper;
using PetTracker.API.DTO;

namespace PetTracker.API.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Pet, PetOutDTO>().ReverseMap();
        CreateMap<Owner, OwnerInDTO>().ReverseMap();
        CreateMap<Pet, NewPetDTO>().ReverseMap();
        CreateMap<Pet, UpdatePetDTO>().ReverseMap();
    }
}