using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using WpfMvvm.Messages;
using WpfMvvm.Services;
using WpfMvvm.Tools;

namespace WpfMvvm.ViewModels
{  
    class TestViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Properties
        private string message;
        [Required(ErrorMessage = "Message is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Message
        {
            get => message;
            set => Set(ref message, value);
        }
        #endregion

        #region Validation
        public string Error => throw new NotImplementedException();
        public string this[string columnName] => this.Validate(columnName); 
        #endregion

        #region Dependencies
        private readonly ITestService testService;
        #endregion

        #region Constructors
        public TestViewModel(ITestService testService)
        {            
            this.testService = testService;
        }
        #endregion

        #region Commands
        private RelayCommand<string> messageCommand;
        public RelayCommand<string> MessageCommand
        {
            get
            {
                return messageCommand ?? (messageCommand = new RelayCommand<string>(
                    param => Messenger.Default.Send(new TestMessage() { Text = Message }),
                    param => String.IsNullOrWhiteSpace(this["Message"])
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
        #endregion
    }
}
