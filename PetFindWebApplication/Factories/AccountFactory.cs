using PetFindWebApplication.DAL;
using PetFindWebApplication.Data;

namespace PetFindWebApplication.Factories
{
    public class AccountFactory : AbstractAccountFactory
    {
        public override AbstractAccountDataGateway CreateAccountGateway(PetFindWebApplicationContext context)
        {
            return new AccountGateway(context);
        }
    }
}
