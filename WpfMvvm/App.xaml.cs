using System;
using System.IO;
using System.Windows;
using WpfMvvm.Tools;
using WpfMvvm.Views;

namespace WpfMvvm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            try
            {
                var app = new AppView();
                app.DataContext = new ViewModelLoactor().AppViewModel;
                app.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
