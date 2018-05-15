using GalaSoft.MvvmLight;

namespace WpfMvvm.Navigation
{
    interface INavigationService
    {
        ViewModelBase Current { get; set; }
        void NavigateTo(VM name);
        void GoBack();
        void ClearHistory();
        void AddPage(ViewModelBase page, VM name);
        void RemovePage(VM name);
    }
}
