using Microsoft.AspNetCore.Mvc;
using PetTracker.API.DTO;
using PetTracker.API.Model;
using PetTracker.API.Service;

namespace PetTracker.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class OwnerController : ControllerBase
{   
    private readonly IOwnerService _ownerService;

    public OwnerController(IOwnerService ownerService) => _ownerService = ownerService;

    [HttpGet]
    public IActionResult GetAllOwners()
    {
        var ownerList = _ownerService.GetAllOwners();
        return Ok(ownerList);
    }

    [HttpGet("{id}")]
    public IActionResult GetOwnerById(int id)
    {
        try
        {
            var foundOwner = _ownerService.GetOwnerById(id);
            return Ok(foundOwner);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateNewOwner(OwnerInDTO newOwner)
    {
        var owner = _ownerService.CreateNewOwner(newOwner);
        return Ok(owner);
    }

    [HttpDelete]
    public IActionResult DeleteOwnerById(int id)
    {
        try
        {
            var foundOwner = _ownerService.DeleteOwnerById(id);
            return Ok(foundOwner);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}