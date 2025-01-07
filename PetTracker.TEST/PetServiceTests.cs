using Moq;
using PetTracker.API.Model;
using PetTracker.API.Repository;
using PetTracker.API.Service;

namespace PetTracker.TEST;

public class UnitTest1
{
    [Fact]
    public void TestCreateNewPet()
    {
        //Arrange
        Mock<IPetRepository> mockRepo = new();
        PetService petService = new(mockRepo.Object);

        List<Pet> petList = [
            new Pet{Id = 1, Name = "Nyla"},
            new Pet{Id = 2, Name = "Deuce"},
            new Pet{Id = 3, Name = "Stella"},
            new Pet{Id = 4, Name = "Cali"}
        ];

        Pet newPet = new Pet{Id = 5, Name = "Rover"};

        mockRepo.Setup(repo => repo.CreateNewPet(It.IsAny<Pet>()))
            .Callback((Pet p) => petList.Add(p))
            .Returns(newPet);
        
        //Act
        var myPet = petService.CreateNewPet(newPet);

        //Assert
        Assert.Contains(newPet, petList);
        mockRepo.Verify(x => x.CreateNewPet(It.IsAny<Pet>()), Times.Once());
    }

    [Fact]
    public void GetAllPetsTest()
    {
        //Arrange
        Mock<IPetRepository> mockRepo = new();
        PetService petService = new(mockRepo.Object);

        List<Pet> petList = [
            new Pet{Id = 1, Name = "Nyla"},
            new Pet{Id = 2, Name = "Deuce"},
            new Pet{Id = 3, Name = "Stella"},
            new Pet{Id = 4, Name = "Cali"}
        ];

        mockRepo.Setup(repo => repo.GetAllPets()).Returns(petList);
        
        //Act
        var result = petService.GetAllPets().ToList();
        
        //Assert
        Assert.Equal(petList, result);
    }
}