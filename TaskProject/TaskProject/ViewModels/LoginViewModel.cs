
namespace TaskProject.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _fullName = null!;
        public string FullName
        {
            get => _fullName;
            set => Set(ref _fullName, value);
        }

        private string _phone = null!;
        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        private DateTime? _birthDate = null!;
        public DateTime? BirthDate
        {
            get => _birthDate;
            set => Set(ref _birthDate, value);
        }

        private string _login = null!;
        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        private string _password = null!;
        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public ICommand AddEmployee { get; }
        public ICommand EmployeeList { get; }

        public LoginViewModel()
        {
            AddEmployee = new RelayCommand(AddEmployeeExecute, AddEmployeeCanExecute, this);
            EmployeeList = new RelayCommand(EmployeeListExecute);
        }

        private bool AddEmployeeCanExecute(object? parameter)
        {
            return !new[] { _fullName, _birthDate?.ToString(), _phone, _login, _password }.Any(string.IsNullOrWhiteSpace);
        }

        private void AddEmployeeExecute(object? parameter)
        {
            var employee = new Employee
            {
                FullName = _fullName,
                BirthDate = DateOnly.FromDateTime(_birthDate!.Value),
                Phone = _phone,
                Login = _login,
                Password = _password
            };
            DB.AddEmployee(employee);
            EmployeeListExecute(parameter);
        }

        private void EmployeeListExecute(object? parameter)
        {
            App.Navigate(new EmployeeListViewModel());
        }
    }
}
