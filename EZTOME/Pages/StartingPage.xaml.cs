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
    /// Логика взаимодействия для StartingPage.xaml
    /// </summary>
    public partial class StartingPage : Page
    {
        public StartingPage()
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
            List<DB.Client> ClientList = Connection.Client.ToList();

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
                foreach (DB.Employers Employeers in EmployeersList)
                {
                    if (Login == Employeers.Login)
                    {
                        MessageBox.Show("Пользователь с таким Логином уже зарегестрирован!");
                        error = true;
                        break;
                    }
                }
                foreach (DB.Client clients in ClientList)
                {

                    if (Login == clients.Login)
                    {
                        MessageBox.Show("Пользователь с таким Логином уже зарегестрирован!");
                        error = true;
                        break;
                    }
                }
                if (error == false)
                {
                    DB.Client USERSB = new DB.Client();
                    USERSB.Login = Login;
                    USERSB.Password = Password;
                    USERSB.FirstName = FirstName;
                    USERSB.Email = Mail;
                    USERSB.SurName = SurName;
                    USERSB.Patronymic = Patronymic;

                    Connection.Client.Add(USERSB);

                    int result = Connection.SaveChanges();
                    if (result == 1)
                    {
                        Clear();
                        MessageBox.Show("Пользователь успешно добавлен!");
                        User.UserName = Login;
                        NavigationService.Navigate(Pages.Client_Page);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: Пользователь не добавлен");
                    }

                }
            }
        }

        private void But_Authorization_Click(object sender, RoutedEventArgs e)
        {
            string Login = Text_Login1.Text;
            string Password = Text_Password1.Password;

            List<DB.Client> ClientList = Connection.Client.ToList();
            List<DB.Employers> EmployersList = Connection.Employers.ToList();
            bool Error = true;


            if ((Login.Length != 0) && (Password.Length != 0))
            {
                foreach (DB.Client Clients in ClientList)
                {
                    if ((Login == Clients.Login) && (Password == Clients.Password))
                    {
                        MessageBox.Show("Здравствуйте," + Clients.FirstName);
                        Text_Login1.Text = "";
                        Text_Password1.Password = "";
                        Error = false;
                        User.UserName = Login;
                        NavigationService.Navigate(Pages.Client_Page);
                        return;
                    }
                }
                foreach (DB.Employers employers in EmployersList)
                {
                    if ((Login == employers.Login) && (Password == employers.Password))
                    {
                        Error = false;
                        User.UserName = Login;
                        Text_Login1.Text = "";
                        Text_Password1.Password = "";
                        MessageBox.Show("Здравствуйте," + employers.FisrstName);
                        if (employers.Role == "Программист")
                        {
                            NavigationService.Navigate(Pages.Employers_Page);
                            return;
                        }
                        if (employers.Role == "Администратор")
                        {
                            NavigationService.Navigate(Pages.Admin_Page);
                            return;
                        }
                        if (employers.Role == "TeamLead")
                        {
                            NavigationService.Navigate(Pages.TeamLead_Page);
                            return;
                        }

                    }
                }
            }
           
            if (Error)
            {
                MessageBox.Show("Неправильный логин или пароль");
                Clear();
            }
        }
    }
}
