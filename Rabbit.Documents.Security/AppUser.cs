using Raven.Identity;

namespace Rabbit.Documents.Security
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
