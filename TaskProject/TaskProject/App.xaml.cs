using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TaskProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly static AppViewModel _appViewModel;
        static App()
        {
            _appViewModel = new(new RegisterViewModel());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow
            {
                DataContext = _appViewModel
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        public static void Navigate(ViewModelBase viewModel)
        {
            _appViewModel.CurrentViewModel = viewModel;
        }
    }
}
