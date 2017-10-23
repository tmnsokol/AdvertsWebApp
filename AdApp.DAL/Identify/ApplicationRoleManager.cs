using AdApp.DAL.Entities.Identity;
using Microsoft.AspNet.Identity;

namespace AdApp.DAL.Identify
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store)
            : base(store)
        { }
    }
}