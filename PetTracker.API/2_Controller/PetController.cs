using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetTracker.API.DTO;
using PetTracker.API.Model;
using PetTracker.API.Service;

namespace PetTracker.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{   
    private readonly IPetService _petService;

    public PetController(IPetService petService)
    {
        _petService = petService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewPet(NewPetDTO newPet)
    {
        var pet = _petService.CreateNewPet(newPet);
        return Ok(await pet);
    }

    [HttpGet]
    public IActionResult GetAllPets()
    {
        var petList = _petService.GetAllPets();    
        return Ok(petList);
    }    

    [HttpGet("id/{id}")]
    public IActionResult GetPetById(int id)
    {
        var findPet = _petService.GetPetById(id);

        if(findPet is null) return NotFound();
        
        return Ok(findPet);
    }

    [HttpGet("name/{name}")]
    public IActionResult GetPetByName(string name)
    {
        var petList = _petService.GetPetByName(name);
        return Ok(petList);
    }    

    [HttpPut]
    public IActionResult UpdatePet(UpdatePetDTO updatePet)
    {
        var pet = _petService.UpdatePet(updatePet);

        //pet does not exist
        if(pet is null) return BadRequest("That pet does not exist!");

        //update pet
        return Ok(pet);
    }    

    [HttpDelete]
    public IActionResult DeletePet(int id)
    {
        var deletePet = _petService.DeletePetById(id);

        if(deletePet is null) return NotFound();

        return Ok(deletePet);
    }
}