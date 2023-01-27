namespace TaskProject.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly Employee _employee;

        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }
        public Employee Employee => _employee;
        public string FullName => _employee.FullName;
        public string BirthDate => _employee.BirthDate.ToLongDateString();
        public string Phone => _employee.Phone;
        public string Login => _employee.Login;
        public string Password => _employee.Password;
        public string Status
        {
            get => _employee.Status;
            set
            {
                _employee.Status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
    }
}
