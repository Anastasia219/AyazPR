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
    /// Логика взаимодействия для DepartmentPage.xaml
    /// </summary>
    public partial class DepartmentPage : Page
    {
        public DepartmentPage()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            Departament departament = DList.SelectedItem as Departament;
            if (departament != null)
                Navigation.NextPage(new PageComponents("Редактирование", new RedPage(departament)));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Departament departament = DList.SelectedItem as Departament;
            if (departament != null)
                App.db.Departament.Remove(departament);
            App.db.SaveChanges();
            DList.ItemsSource = App.db.Departament.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponents("Редактирование", new RedPage(new Departament())));
        }

        private void Filtercb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Departament> serviceSortList = App.db.Departament;
            if (Filtercb.SelectedIndex != null)
            {
                if (Filtercb.SelectedIndex == 0)
                {
                    serviceSortList = serviceSortList.OrderBy(x => x.Name_Departament);
                }
                else if (Filtercb.SelectedIndex == 1)
                {
                    serviceSortList = serviceSortList.OrderByDescending(x => x.Name_Departament);
                }

            }
            if (SerchTb.Text != null)
            {
                serviceSortList = serviceSortList.Where(x => x.Name_Departament.ToLower().Contains(SerchTb.Text.ToLower()) || x.Name_Departament.ToLower().Contains(SerchTb.Text.ToLower())); //поиск по слову
            }
            DList.ItemsSource = serviceSortList.ToList();
        }

        private void SerchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
