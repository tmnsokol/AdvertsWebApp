using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AdApp.BLL.DTO;
using AdWebApp.Models;
using AutoMapper;
using AutoMapper.Configuration;

namespace AdWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var config = new MapperConfigurationExpression();
            config.CreateMap<AdvertDto, AdvertViewModel>();
            config.CreateMap<ClientProfileDto, ClientProfileModel>();
            config.CreateMap<ClientProfileModel, ClientProfileDto>();
            config.CreateMap<AdvertViewModel, AdvertDto>();
            Mapper.Initialize(config);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}