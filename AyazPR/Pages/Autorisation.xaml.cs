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
    /// Логика взаимодействия для Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Page
    {
        public Autorisation()
        {
            InitializeComponent();
        }


        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            var User = App.db.Employee.Where(x => x.Id_Number.ToString() == PasswordPB.Password).FirstOrDefault() as Employee;
            if (App.db.Boss.Where(x => x.Id_Boss.ToString() == PasswordPB.Password).FirstOrDefault() != null)
            {
                App.IsHeadDepartment = true;
                MessageBox.Show("Здравствуй Заведующий Кафедры");
                InfoUser.IDBoss = Convert.ToInt32(PasswordPB.Password);
                Navigation.NextPage(new PageComponents("Список", new SelectionPage()));
            }
            else if (App.db.Engineer.Where(x => x.Id_Engineer.ToString() == PasswordPB.Password).FirstOrDefault() != null)
            {
                App.IsEngineer = true;
                InfoUser.IDEmploy = Convert.ToInt32(PasswordPB.Password);
                MessageBox.Show("Здравствуй Инженер");
                Navigation.NextPage(new PageComponents("Список", new EmployeePage()));
            }
            else if (App.db.Employee.Where(x => x.Id_Number.ToString() == PasswordPB.Password && x.Id_Rank.ToString() != null).FirstOrDefault() != null)
            {
                InfoUser.IDTeacher = Convert.ToInt32(PasswordPB.Password);
                App.IsTeacher = true;
                MessageBox.Show("Здравствуй Преподаватель");
                Navigation.NextPage(new PageComponents("Список", new EmployeePage()));

            }
            else if (App.db.Student.Where(x => x.Id_Student.ToString() == PasswordPB.Password).FirstOrDefault() != null)
            {
                InfoUser.IdStudent = Convert.ToInt32(PasswordPB.Password);
                MessageBox.Show("Здравствуй студент");
                Navigation.NextPage(new PageComponents("Список", new DisciplinesPage()));
            }
            else
            {
                MessageBox.Show("Неверный пароль. Попробуйте заново");
            }
        }
    }
}
