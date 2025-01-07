using Microsoft.EntityFrameworkCore;
using PetTracker.API.Model;

namespace PetTracker.API.Data;

public partial class PetContext : DbContext
{
    public PetContext(){}
    public PetContext(DbContextOptions<PetContext> options) : base(options){}

    public virtual DbSet<Pet> Pets { get; set; }
    public virtual DbSet<Owner> Owners { get; set; }

}