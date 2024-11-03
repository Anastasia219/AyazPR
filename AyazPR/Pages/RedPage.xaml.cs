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
    /// Логика взаимодействия для RedPage.xaml
    /// </summary>
    public partial class RedPage : Page
    {
        private Departament departament;
        public RedPage(Departament _department)
        {
            InitializeComponent();
            departament = _department;
            this.DataContext = departament;
            
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();//создание строки ошибки 

            if (departament.Cipher != null)
            {
                if (App.db.Departament.Any(x => x.Name_Departament == departament.Name_Departament))
                {
                    error.AppendLine("Такая кафедра УЖЕ есть!!!!!!!!!!!!");
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    App.db.Departament.Add(departament);

                }
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            App.db.SaveChanges();


            MessageBox.Show("Сохранено");
            Navigation.NextPage(new PageComponents("Список услуг", new DepartmentPage()));

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
