using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public IActionResult GetAllPets()
    {
        var petList = _petService.GetAllPets();    
        return Ok(petList);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewPet(Pet newPet)
    {
        var pet = _petService.CreateNewPet(newPet);
        return Ok(await pet);
    }

    [HttpGet("{id}")]
    public IActionResult GetPetById(int id)
    {
        var findPet = _petService.GetPetById(id);

        if(findPet is null) return NotFound();
        
        return Ok(findPet);
    }

    [HttpDelete]
    public IActionResult DeletePet(int id)
    {
        var deletePet = _petService.DeletePetById(id);

        if(deletePet is null) return NotFound();

        return Ok(deletePet);
    }

    [HttpPut]
    public IActionResult UpdatePet(Pet updatePet)
    {
        var pet = _petService.GetPetById(updatePet.Id);

        //pet does not exist
        if(pet is null) return BadRequest();

        //update pet
        return Ok();
    }

    [HttpGet("name/{name}")]
    public IActionResult GetPetByName(string name)
    {
        var petList = _petService.GetPetByName(name);
        return Ok(petList);
    }

    // [HttpDelete]
    // public IActionResult DeletePet(int id)
    // {

    // }
}