using PetFindWebApplication.DAL;
using PetFindWebApplication.Data;

namespace PetFindWebApplication.Factories
{
    public abstract class AbstractAccountFactory
    {
        public abstract AbstractAccountDataGateway CreateAccountGateway(PetFindWebApplicationContext context);
    }
}
