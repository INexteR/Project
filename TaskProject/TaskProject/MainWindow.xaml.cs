global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using System.Windows;
global using System.Windows.Controls;
global using System.Windows.Data;
global using System.Windows.Documents;
global using System.Windows.Input;
global using System.Windows.Media;
global using System.Windows.Media.Imaging;
global using System.Windows.Navigation;
global using System.Windows.Shapes;
global using System.Windows.Controls.Primitives;
global using System.ComponentModel;
global using System.Collections;
global using System.Collections.ObjectModel;
global using System.Runtime.CompilerServices;
global using Microsoft.EntityFrameworkCore;
global using TaskProject.Models;
global using TaskProject.Views;
global using TaskProject.ViewModels;
global using TaskProject.Commands;
global using Wd = Microsoft.Office.Interop.Word;
using System.Globalization;

namespace TaskProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

    }
    public class ContentToTitleConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value switch
        {
            RegisterViewModel => "Вход",
            LoginViewModel => "Регистрация",
            _ => "Просмотр сотрудников"
        };


        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
