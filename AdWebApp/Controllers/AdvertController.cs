using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AdApp.BLL.DTO;
using AdWebApp.Converters;
using AdWebApp.Models;
using Microsoft.AspNet.Identity;

namespace AdWebApp.Controllers
{
    [Authorize]
    public class AdvertController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var adverts = await AdvertService.GetAllAdverts();
            var vms = new List<AdvertViewModel>();
            if (adverts != null)
            {
                vms = adverts.Select(advertDto => advertDto.ToViewModel()).ToList();
            }

            return View(vms);
        }

        public async Task<ActionResult> UserAdverts()
        {
            var adverts = await AdvertService.GetAdvertsByUserId(User.Identity.GetUserId());
            var vms = new List<AdvertViewModel>();
            if (adverts != null)
            {
                vms = adverts.Select(advertDto => advertDto.ToViewModel()).ToList();
            }

            return View(vms);
        }

        public async Task<ActionResult> Details(int id)
        {
            var advert = await AdvertService.GetAdvertById(id);
            AdvertViewModel vm = null;
            if (advert != null)
            {
                vm = advert.ToViewModel();
                var client = await UserService.GetClientProfileById(advert.UserId);
                vm.ClientProfile = client.ToViewModel();
            }

            return View(vm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(AdvertViewModel advertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(advertViewModel);
            }

            var advertDto = new AdvertDto()
            {
                UserId = User.Identity.GetUserId(),
                Title = advertViewModel.Title,
                Content = advertViewModel.Content
            };

            await AdvertService.AddAdvert(advertDto);
            return RedirectToAction("UserAdverts");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var advertDto = await AdvertService.GetAdvertById(id);
            var vm = advertDto.ToViewModel();
            return View(vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Edit(AdvertViewModel advertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(advertViewModel);
            }

            var advertDto = new AdvertDto()
            {
                Id = advertViewModel.Id,
                UserId = User.Identity.GetUserId(),
                Title = advertViewModel.Title,
                Content = advertViewModel.Content
            };

            await AdvertService.UpdateAdvert(advertDto);
            return RedirectToAction("UserAdverts");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var advertDto = await AdvertService.GetAdvertById(id);
            var vm = advertDto.ToViewModel();
            return View(vm);
        }

        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Delete(AdvertViewModel advertViewModel)
        {
            await AdvertService.DeleteAdvert(advertViewModel.Id);
            return RedirectToAction("UserAdverts");
        }
    }
}