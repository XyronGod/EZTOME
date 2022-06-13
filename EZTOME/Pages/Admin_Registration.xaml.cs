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

namespace EZTOME.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin_Registration.xaml
    /// </summary>
    public partial class Admin_Registration : Page
    {
        public Admin_Registration()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            Text_Login.Text = "";
            Text_Password.Text = "";
            Text_FirstName.Text = "";
            Text_SurName.Text = "";
            Text_Patronymic.Text = "";
            Text_Mail.Text = "";
        }

        DB.NetHammerEntities Connection = new DB.NetHammerEntities();


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            List<DB.Employers> EmployeersList = Connection.Employers.ToList();

            string Login = Text_Login.Text;
            string Password = Text_Password.Text;
            string FirstName = Text_FirstName.Text;
            string SurName = Text_SurName.Text;
            string Patronymic = Text_Patronymic.Text;
            string Mail = Text_Mail.Text;
            bool error = false;


            if (Login.Length == 0 || Password.Length == 0 || FirstName.Length == 0 || SurName.Length == 0 || Patronymic.Length == 0 || Mail.Length == 0)
            {
                MessageBox.Show("Вы не заполнили поле!");
            }
            else
            {
                if (error == false)
                {
                    DB.Employers USERSB = new DB.Employers();
                    USERSB.Login = Login;
                    USERSB.Password = Password;
                    USERSB.FisrstName = FirstName;
                    USERSB.Email = Mail;
                    USERSB.SurName = SurName;
                    USERSB.Patronymic = Patronymic;
                    USERSB.Role = "Администратор";
                    

                    Connection.Employers.Add(USERSB);

                    int result = Connection.SaveChanges();
                    if (result == 1)
                    {
                        Clear();
                        MessageBox.Show("Пользователь успешно добавлен!");
                        NavigationService.Navigate(Pages.Admin_Page);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: Пользователь не добавлен");
                    }

                }
            }
        }
    }
}
