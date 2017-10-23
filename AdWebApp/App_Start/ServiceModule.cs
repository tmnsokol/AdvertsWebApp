//using Ninject.Modules;

//namespace AdWebApp
//{
//    public class ServiceModule : NinjectModule
//    {
//        private readonly string _connectionString;
//        public ServiceModule(string connection)
//        {
//            _connectionString = connection;
//        }
//        public override void Load()
//        {
//            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connectionString);
//        }
//    }
//}