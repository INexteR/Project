
namespace TaskProject.Commands
{
    public class RelayCommand : CommandBase
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;
        private readonly string[]? _props;

        public override bool CanExecute(object? parameter)
        {
            return _canExecute is null || _canExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public RelayCommand(Action<object?> execute)
        {
            _execute = execute;
        }

        public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute, ViewModelBase viewModel, params string[] props) : this(execute)
        {
            _canExecute = canExecute;
            _props = props;

            viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (_props!.Length is 0 || _props!.Contains(e.PropertyName!))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
