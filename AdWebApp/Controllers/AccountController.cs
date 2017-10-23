using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AdApp.BLL.DTO;
using AdWebApp.Converters;
using AdWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace AdWebApp.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userDto = new UserDto
            {
                Email = model.Email,
                Password = model.Password,
                Roles = new List<string>() { "admin" },
                Name = model.Name
            };

            var operationDetails = await UserService.Create(userDto);
            if (operationDetails.Succedeed)
            {
                var claim = await UserService.Authenticate(userDto);
                AuthenticationManager.SignOut();
                AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true, }, claim);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return View(model);
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userDto = new UserDto { Email = model.Email, Password = model.Password };
            var claim = await UserService.Authenticate(userDto);
            if (claim == null)
            {
                ModelState.AddModelError("", "Invalid login or password.");
            }
            else
            {
                AuthenticationManager.SignOut();
                AuthenticationManager.SignIn(new AuthenticationProperties()
                { IsPersistent = false, }, claim);

                var returnUrl = Request.Params["ReturnUrl"];
                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home");

                }
                return Redirect(returnUrl);
            }

            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public async Task<ActionResult> Index()
        {
            var clientProfiles = await UserService.GetClientProfiles();
            return View(clientProfiles.ToViewModel());
        }

        public async Task<ActionResult> Details(string id)
        {
            var clientProfileDto = await UserService.GetClientProfileById(id);
            return View(clientProfileDto.ToViewModel());
        }

        public async Task<ActionResult> Delete(string id)
        {
            var userId = User.Identity.GetUserId();
            if (userId.Equals(id))
            {
                return RedirectToAction("Index");
            }

            var clientProfiles = await UserService.GetClientProfileById(id);
            return View(clientProfiles.ToViewModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Delete(ClientProfileModel clientProfileModel)
        {
            var dto = clientProfileModel.ToDto();
            await UserService.Delete(dto);

            return RedirectToAction("Index");
        }
    }
}