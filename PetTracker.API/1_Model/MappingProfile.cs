using AutoMapper;
using PetTracker.API.DTO;

namespace PetTracker.API.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Pet, PetOutDTO>()
            .ForMember(s => s.OwnersDTO, c => c.MapFrom(m => m.Owners));

        CreateMap<Owner, OwnerInDTO>().ReverseMap();
    }
}