using FirstApp.Entities;
using FirstApp.Helpers;

namespace FirstApp.Repository
{
    public class EfCoreUserRepository : EfCoreRepository<User, DataContext>
    {
        public EfCoreUserRepository(DataContext context) : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }
}
