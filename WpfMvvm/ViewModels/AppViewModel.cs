using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using WpfMvvm.Messages;
using WpfMvvm.Navigation;

namespace WpfMvvm.ViewModels
{
    class AppViewModel : ViewModelBase
    {
        #region Properties
        private ViewModelBase currentPage;
        public ViewModelBase CurrentPage
        {
            get => currentPage;
            set => Set(ref currentPage, value);
        }

        private string testText;
        public string TestText
        {
            get => testText;
            set => Set(ref testText, value);
        }
        #endregion

        #region Dependencies
        INavigationService navigationService;
        #endregion

        #region Constructors
        public AppViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            Messenger.Default.Register<ViewModelBase>(this,
                param => CurrentPage = param
            );

            Messenger.Default.Register<TestMessage>(this,
                param => MessageBox.Show(param.Text, "Message from TestVM to AppVM")
            );
        } 
        #endregion
    }
}
