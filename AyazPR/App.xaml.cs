using AyazPR.DBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AyazPR
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static Ych_PR_KMEntities db = new Ych_PR_KMEntities();
        public static MainWindow mainWindow;
        public static bool IsHeadDepartment;
        public static bool IsEngineer;
        public static bool IsTeacher;
    }
}
