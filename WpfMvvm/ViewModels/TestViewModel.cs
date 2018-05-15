using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using WpfMvvm.Messages;
using WpfMvvm.Services;

namespace WpfMvvm.ViewModels
{
    class TestViewModel : ViewModelBase
    {
        private readonly ITestService testService;


        public TestViewModel(ITestService testService)
        {
            this.testService = testService;
        }


        private RelayCommand<string> messageCommand;
        public RelayCommand<string> MessageCommand
        {
            get
            {
                return messageCommand ?? (messageCommand = new RelayCommand<string>(
                    param => Messenger.Default.Send(new TestMessage { Text = "Hello!" })
                ));
            }
        }

        private RelayCommand<string> serviceCommand;
        public RelayCommand<string> ServiceCommand
        {
            get
            {
                return serviceCommand ?? (serviceCommand = new RelayCommand<string>(
                    param => MessageBox.Show(testService.Test())
                ));
            }
        }
    }
}
