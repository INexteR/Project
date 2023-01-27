
namespace TaskProject.ViewModels
{
    public class EmployeeListViewModel : ViewModelBase
    {
        public ICommand Registration { get; }
        public ICommand Dismiss { get; }
        public ICommand PrintJournal { get; }
        public ICommand PrintDismissed { get; }

        public IEnumerable SortItems { get; }
        private readonly ObservableCollection<EmployeeViewModel> _employees;
        public readonly CollectionViewSource _cvs;
        public ListCollectionView Employees { get; }

        public EmployeeListViewModel()
        {
            _employees = new(DB.GetEmployees().Select(e => new EmployeeViewModel(e)));
            _cvs = new CollectionViewSource
            {
                Source = _employees
            };
            Employees = (ListCollectionView)_cvs.View;
            _cvs.Filter += Searching;
            Registration = new RelayCommand(RegistrationExecute);
            PrintJournal = new RelayCommand(PrintJournalExecute);
            PrintDismissed = new RelayCommand(PrintDismissedExecute);
            Dismiss = new RelayCommand(DismissExecute, DismissCanExecute, this, nameof(SelectedEmployee), nameof(EmployeeViewModel.Status));
            var c = Comparer<EmployeeViewModel>.Create;
            string[] texts = { "ФИО", "Телефон", "Дата рождения"};
            (IComparer, IComparer)[] values =
            {
                (
                    c((e1, e2) => e1.FullName.CompareTo(e2.FullName)),
                    c((e1, e2) => e2.FullName.CompareTo(e1.FullName))
                ),
                (
                    c((e1, e2) => e1.Phone.CompareTo(e2.Phone)),
                    c((e1, e2) => e2.Phone.CompareTo(e1.Phone))
                ),
                (
                    c((e1, e2) => e1/*.Employee*/.BirthDate.CompareTo(e2/*.Employee*/.BirthDate)),
                    c((e1, e2) => e2/*.Employee*/.BirthDate.CompareTo(e1/*.Employee*/.BirthDate))
                )
            };
            object[] sortItems = new object[3];
            for (int i = -1; ++i < 3;)
            {
                sortItems[i] = new { Text = texts[i], Value = values[i] };
            }
            SortItems = sortItems;
        }

        private void Searching(object sender, FilterEventArgs e)
        {
            var name = ((EmployeeViewModel)e.Item).FullName;
            if (!name.Contains(_search, StringComparison.InvariantCultureIgnoreCase))
            {
                e.Accepted = false;
            }
        }

        private string _search = string.Empty;
        public string Search
        {
            get => _search;
            set
            {
                Set(ref _search, value);
                _cvs.View.Refresh();
            }
        }

        private bool _ascending;
        public bool Ascending
        {
            get => _ascending;
            set
            {
                if (value == _ascending)
                {
                    Employees.CustomSort = null;
                    value = false;
                }
                else if (value)
                {
                    Employees.CustomSort = _sortItem!.Value.asc;
                }
                Set(ref _ascending, value);
            }
        }
        private bool _descending;
        public bool Descending
        {
            get => _descending;
            set
            {
                if (value == _descending)
                {
                    Employees.CustomSort = null;
                    value = false;
                }
                else if (value)
                {
                    Employees.CustomSort = _sortItem!.Value.desc;
                }
                Set(ref _descending, value);
            }
        }

        private (IComparer asc, IComparer desc)? _sortItem;
        public (IComparer asc, IComparer desc)? SortItem
        {
            get => _sortItem;
            set
            {
                if (value.HasValue)
                {
                    if (_ascending)
                        Employees.CustomSort = value.Value.asc;
                    else if (_descending)
                        Employees.CustomSort = value.Value.desc;
                }
                else
                {
                    if (_ascending)
                        Ascending = false;
                    else if (_descending)
                        Descending = false;
                }
                Set(ref _sortItem, value);
            }
        }

        private EmployeeViewModel _selectedEmployee = null!;
        public EmployeeViewModel SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                if (_selectedEmployee != null)
                {
                    _selectedEmployee.PropertyChanged -= SelectedEmployeePropertyChanged;
                }
                Set(ref _selectedEmployee!, value);
                if (_selectedEmployee != null)
                {
                    _selectedEmployee.PropertyChanged += SelectedEmployeePropertyChanged;
                }
            }
        }

        private void SelectedEmployeePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName!);
        }

        private void RegistrationExecute(object? parameter)
        {
            App.Navigate(new LoginViewModel());
        }

        private void DismissExecute(object? parameter)
        {
            DB.RemoveEmployee(_selectedEmployee.Employee);
            _employees.Remove(_selectedEmployee);
        }

        private bool DismissCanExecute(object? parameter)
        {
            return _selectedEmployee is not null and { Status: "Уволен" };
        }

        private void PrintJournalExecute(object? parameter)
        {
            DB.PrintJournal();
        }

        private void PrintDismissedExecute(object? parameter)
        {
            DB.PrintDismissed();
        }
    }
}
