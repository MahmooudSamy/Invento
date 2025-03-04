using Autofac;
using System.Windows;

namespace Invento.Container
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var bulider = new ContainerBuilder();

           
            return bulider.Build();
        }
    }
}
