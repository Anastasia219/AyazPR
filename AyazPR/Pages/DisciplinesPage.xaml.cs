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
    /// Логика взаимодействия для DisciplinesPage.xaml
    /// </summary>
    public partial class DisciplinesPage : Page
    {
        public DisciplinesPage()
        {
            InitializeComponent();
            BList.ItemsSource = App.db.StudentDiscipline.Where(x => x.Id_Student == InfoUser.IdStudent).ToList();
            last.Text = App.db.Student.Where(x => x.Id_Student == InfoUser.IdStudent).FirstOrDefault().LastName_Student;
            DataContext = this;

        }
    }
}
