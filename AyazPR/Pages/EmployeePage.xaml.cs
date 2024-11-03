using AyazPR.DBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AyazPR.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            EList.ItemsSource = App.db.Employee.ToList();

        }
        private void SerchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Employee> EmployeeeSortList = App.db.Employee;
            if (SerchTb.Text != null)
            {
                EmployeeeSortList = EmployeeeSortList.Where(x => x.LastName.ToLower().Contains(SerchTb.Text.ToLower()) || x.LastName.ToLower().Contains(SerchTb.Text.ToLower())); //поиск по слову
                EList.ItemsSource = EmployeeeSortList;
            }

            CountDataTb.Text = EmployeeeSortList.Count() + "из" + App.db.Employee.Count();// выводить сколько данных показывается из всех



        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = EList.SelectedItem as Employee;
            Navigation.NextPage(new PageComponents("Редактирование", new EditPage(employee)));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = EList.SelectedItem as Employee;
            App.db.Employee.Remove(employee);
            App.db.SaveChanges();
            EList.ItemsSource = App.db.Employee.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponents("Редактирование", new EditPage(new Employee())));
        }
    }
}
