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

namespace EZTOME
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SuperAdminChecked();
            bool checkedAdmin = false;
            var Roles = Connection.Employers.ToList();
            foreach (var role in Roles)
            {
                if (role.Role == "Администратор")
                {
                    checkedAdmin = true;
                }
            }
            if (checkedAdmin == true)
            {
                MainFrame.NavigationService.Navigate(Pages.Pages.StartingPage);
            }
        }

        
        DB.NetHammerEntities Connection = new DB.NetHammerEntities();

        public void SuperAdminChecked()
        {
            var Roles = Connection.Employers.ToList();
            bool checkedAdmin = false;
            foreach (var role in Roles)
            {
                if (role.Role == "Администратор")
                {
                    checkedAdmin = true;
                }
            }
            if (checkedAdmin == false)
            {
                string messageBoxText = "Не найден пользователь Администратор. Для полного использования " +
                    "функционала приложения нужно создать Администратора. Создать его?";
                string caption = "Проверка супер-пользователя";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MainFrame.NavigationService.Navigate(Pages.Pages.Admin_Registration);
                        break;
                    case MessageBoxResult.No:
                        MainFrame.NavigationService.Navigate(Pages.Pages.StartingPage);
                        break;
                }

            }
        }
    }
}
