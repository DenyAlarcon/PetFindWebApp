using Microsoft.AspNetCore.Hosting;
using PetFindWebApplication.DAL;
using PetFindWebApplication.Data;

namespace PetFindWebApplication.Factories
{
    public class AdvertisementFactory : AbstractAdvertisementFactory
    {
        public override AbstractAdvertisementDataGateway CreateAdvertisementGateway(PetFindWebApplicationContext context, IWebHostEnvironment webHostEnvironment)
        {
            return new AdvertisementGateway(context, webHostEnvironment);
        }
    }
}
