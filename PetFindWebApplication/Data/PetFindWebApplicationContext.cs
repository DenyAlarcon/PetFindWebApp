using Microsoft.EntityFrameworkCore;
using PetFindWebApplication.Models;

namespace PetFindWebApplication.Data
{
    public class PetFindWebApplicationContext : DbContext
    {
        public PetFindWebApplicationContext(DbContextOptions<PetFindWebApplicationContext> options): base(options) { }

        public DbSet<Advertisement> Advertisement { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<AnimalType> AnimalType { get; set; }
        public DbSet<AdvertisementType> AdvertisementType { get; set; }
        public DbSet<City> City { get; set; }
    }
}
