using System.Web;
using System.Web.Mvc;
using AdApp.BLL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace AdWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        public IBllServices BllServices => HttpContext.GetOwinContext().GetUserManager<IBllServices>();
        public IUserService UserService => BllServices.UserService;
        public IAdvertService AdvertService => BllServices.AdvertService;
        public IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
    }
}