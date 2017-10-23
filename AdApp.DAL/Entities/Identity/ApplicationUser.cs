using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdApp.DAL.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Advert> Adverts { get; set; }

        public ApplicationUser()
        {
            Adverts = new HashSet<Advert>();
        }
    }
}