using Autofac;
using Invento.DataAccess;
using Invento.DataAccess.Data.Lookups;
using Invento.DataAccess.Data.Repositories;
using Invento.ViewModels;

namespace Invento.Container
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var bulider = new ContainerBuilder();

            bulider.RegisterType<MainWindow>().AsSelf();

            bulider.RegisterType<MainViewModel>().AsSelf();
            bulider.RegisterType<InventoryDbContext>().AsSelf();


            ////services
            bulider.RegisterType<LookupDataService>().AsImplementedInterfaces();
            bulider.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            ////services

            ////repo
            bulider.RegisterType<InventoryItemRepository>().As<IInventoryItemRepository>();
            bulider.RegisterType<ItemRepository>().As<IItemRepository>();
            ////repo

            ////ViewModel

            bulider.RegisterType<ListOfItemsViewModel>().As<IListOfItemsViewModel>();
            bulider.RegisterType<NavigationViewModel>().As<INavigationViewModel>();


          
            //bulider.RegisterType<LogInViewModel>().As<ILogInViewModel>();
            ////ViewModel

            return bulider.Build();
        }
    }
}
