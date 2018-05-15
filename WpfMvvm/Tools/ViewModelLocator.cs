using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using WpfMvvm.Navigation;
using WpfMvvm.ViewModels;

namespace WpfMvvm.Tools
{
    class ViewModelLoactor
    {
        INavigationService navigationService = new NavigationService();


        //TODO: Add VMs 
        public AppViewModel AppViewModel { get; }
        public TestViewModel TestViewModel { get; }


        public ViewModelLoactor()
        {
            try
            {
                var config = new ConfigurationBuilder();
                config.AddJsonFile("autofac.json");
                var module = new ConfigurationModule(config.Build());
                var builder = new ContainerBuilder();
                builder.RegisterModule(module);
                builder.RegisterInstance(navigationService).As<INavigationService>().SingleInstance();
                var container = builder.Build();

                using (var scope = container.BeginLifetimeScope())
                {
                    //TODO: Resolve all VMs
                    AppViewModel = scope.Resolve<AppViewModel>();
                    TestViewModel = scope.Resolve<TestViewModel>();
                }

                //TODO: Add VMs to navigation
                navigationService.AddPage(TestViewModel, VM.Test);

                //TODO: Set default VM
                navigationService.NavigateTo(VM.Test);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
