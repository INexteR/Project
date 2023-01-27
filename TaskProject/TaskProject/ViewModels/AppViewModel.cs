namespace TaskProject.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        public AppViewModel(ViewModelBase currentViewModel)
        {
            _currentViewModel = currentViewModel;
        }
    }
}
