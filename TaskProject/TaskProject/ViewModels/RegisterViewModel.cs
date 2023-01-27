

namespace TaskProject.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public ICommand Register { get; }

        public RegisterViewModel()
        {
            Register = new RelayCommand(RegisterExecute);
        }

        private void RegisterExecute(object? parameter)
        {
            App.Navigate(new LoginViewModel());
        }
    }
}
