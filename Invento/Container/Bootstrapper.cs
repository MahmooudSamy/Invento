using Autofac;
using System.Windows;

namespace Invento.Container
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var bulider = new ContainerBuilder();

            bulider.RegisterType<MainWindow>().AsSelf();



            ////services
            //bulider.RegisterType<LookupDataServices>().AsImplementedInterfaces();
            //bulider.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            ////services

            ////repo
            //bulider.RegisterType<UserReposetry>().As<IUserReposetry>();
            //bulider.RegisterType<QuestionsReposetry>().As<IQuestionsReposetry>();
            //bulider.RegisterType<AnswerReposetry>().As<IAnswerReposetry>();
            ////repo

            ////ViewModel
            //bulider.RegisterType<UserViewModel>().As<IUserViewModel>();
            //bulider.RegisterType<AnswerViewModel>().As<IAnswerViewModel>();
            //bulider.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            //bulider.RegisterType<NotificationViewModel>().As<INotificationViewModel>();
            //bulider.RegisterType<LogInViewModel>().As<ILogInViewModel>();
            ////ViewModel

            return bulider.Build();
        }
    }
}
