using Microsoft.AspNetCore.Hosting;
using PetFindWebApplication.DAL;
using PetFindWebApplication.Data;

namespace PetFindWebApplication.Factories
{
    public abstract class AbstractAdvertisementFactory
    {
        public abstract AbstractAdvertisementDataGateway CreateAdvertisementGateway(PetFindWebApplicationContext context, IWebHostEnvironment webHostEnvironment);
    }
}
