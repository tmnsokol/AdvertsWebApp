//using System;
//using System.Collections.Generic;
//using System.Web.Mvc;
//using AdApp.BLL.Interfaces;
//using AdApp.BLL.Services;
//using Ninject;

//namespace AdWebApp
//{
//    public class NinjectDependencyResolver : IDependencyResolver
//    {
//        private readonly IKernel _kernel;

//        public NinjectDependencyResolver(IKernel kernelParam)
//        {
//            _kernel = kernelParam;
//            addBindings();
//        }

//        public object GetService(Type serviceType)
//        {
//            return _kernel.TryGet(serviceType);
//        }

//        public IEnumerable<object> GetServices(Type serviceType)
//        {
//            return _kernel.GetAll(serviceType);
//        }

//        private void addBindings()
//        {
//            _kernel.Bind<IAdvertService>().To<AdvertService>();
//        }
//    }
//}