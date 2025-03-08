using Autofac;
using Invento.DataAccess;
using Invento.DataAccess.Data.Lookups;
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
            //bulider.RegisterType<UserReposetry>().As<IUserReposetry>();
            //bulider.RegisterType<QuestionsReposetry>().As<IQuestionsReposetry>();
            //bulider.RegisterType<AnswerReposetry>().As<IAnswerReposetry>();
            ////repo

            ////ViewModel
            //bulider.RegisterType<UserViewModel>().As<IUserViewModel>();
            bulider.RegisterType<ListOfItemsViewModel>().As<IListOfItemsViewModel>();
            bulider.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            //bulider.Register(c => new Func<ListOfItemsViewModel>(c.Resolve<ListOfItemsViewModel>));

            //bulider.RegisterType<NotificationViewModel>().As<INotificationViewModel>();
            //bulider.RegisterType<LogInViewModel>().As<ILogInViewModel>();
            ////ViewModel

            return bulider.Build();
        }
    }
}
