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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private Employee employee;
        bool newu;
        public EditPage(Employee _employee)
        {
            InitializeComponent();
            Navigation.mainWindow.QR.Visibility = Visibility.Collapsed;
            employee = _employee;
            this.DataContext = employee;
            if (employee.Id_Number == 0)
                newu = true;
            else newu = false;
            
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();//создание строки ошибки 

            if (App.db.Employee.Any(x => x.LastName == employee.LastName) && newu == true)
            {
                MessageBox.Show("Такой сотрудник УЖЕ есть!!!!!!!!!!!!");
                MessageBox.Show(error.ToString());
            }
            else if (newu == true)
            {
                App.db.Employee.Add(employee);
            }
            App.db.SaveChanges();
            MessageBox.Show("Сохранено");
            Navigation.NextPage(new PageComponents("Список услуг", new EmployeePage()));

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, (0)))
            {
                e.Handled = true;
            }
        }
    }
}
