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
    /// Логика взаимодействия для Admin_Page.xaml
    /// </summary>
    public partial class Admin_Page : Page
    {
        public DB.Employers Employers { get; set; }
        public List<DB.Employers> EmployersList { get; set; }

        DB.NetHammerEntities Connection = new DB.NetHammerEntities();

        public List<DB.Roles> Roles { get; set; }

        public List<DB.Team> Teams { get; set; }

        public Admin_Page()
        {
            InitializeComponent();
            LoadUsers();
            LoadRoles();
            LoadTeams();
            LoadRolesCombo();
            LoadEmployersToList();
            LoadTeamLeads();
            TeamsWTHLeads();
            EmployersList = Connection.Employers.ToList();
            DataContext = this;
        }

        void LoadUsers()
        {
            Text_Login.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            Text_Password.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            Text_Mail.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            Text_FirstName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            Text_Patronymic.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            Text_SurName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            Combo_Role.GetBindingExpression(System.Windows.Controls.Primitives.Selector.SelectedItemProperty)?.UpdateTarget(); // Тут я изменил
            Combo_Team.GetBindingExpression(System.Windows.Controls.Primitives.Selector.SelectedItemProperty)?.UpdateTarget(); // и тут
            List_Employers.GetBindingExpression(ItemsControl.ItemsSourceProperty)?.UpdateTarget(); // и конечно же тут
        }
        void LoadRoles()
        {
            Roles = Connection.Roles.ToList();
        }

        private void LoadRolesCombo()
        {
            List<DB.Roles> RolesList = Connection.Roles.ToList();
            foreach (DB.Roles Role in RolesList)
            {
                Combo_Roles1.Items.Add(Role.Name);
            }
        }
        void LoadTeams()
        {
            Teams = Connection.Team.ToList();
        }

        private void List_Employers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employers = List_Employers.SelectedItem as DB.Employers;
            LoadUsers();
        }

        private void LoadEmployersToList()
        {
            List<DB.Employers> EmployeersList = Connection.Employers.ToList();
            foreach (DB.Employers employers in EmployeersList)
            {
                if (employers.Team == null & employers.Role != "Администратор")
                {
                    _ = List_Employers1.Items.Add(employers.Login);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = Connection.SaveChanges();
            if (result != 0)
            {
                MessageBox.Show("Данные обновлены");
            }
            else
            {
                MessageBox.Show("Ошибка редактировния");
            }
        }
        private void Clear()
        {
            Text_Login1.Text = "";
            Text_Password1.Text = "";
            Text_FirstName1.Text = "";
            Text_SurName1.Text = "";
            Text_Patronymic1.Text = "";
            Text_Mail1.Text = "";
            Combo_Roles1.SelectedItem = -1;
        }

        private void LoadTeamLeads()
        {
            List<DB.Employers> employers = Connection.Employers.ToList();
            foreach (DB.Employers TeamLeads in employers)
            {
                if (TeamLeads.Role == "TeamLead" & TeamLeads.Team == null)
                {
                    List_Employers2.Items.Add(TeamLeads.SurName + " " + TeamLeads.FisrstName + " " + TeamLeads.Patronymic);
                }
            }
        }

        private void TeamsWTHLeads()
        {
            List<DB.Team> team = Connection.Team.ToList();
            foreach (DB.Team team1 in team)
            {
                if (team1.TeamLeader == null)
                {
                    List_Team1.Items.Add(team1.TeamID);
                }
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<DB.Employers> EmployeersList = Connection.Employers.ToList();

            string Login = Text_Login1.Text;
            string Password = Text_Password1.Text;
            string FirstName = Text_FirstName1.Text;
            string SurName = Text_SurName1.Text;
            string Patronymic = Text_Patronymic1.Text;
            string Mail = Text_Mail1.Text;
            string Role = Combo_Roles1.Text;
            bool error = false;


            if (Login.Length == 0 || Password.Length == 0 || FirstName.Length == 0 || SurName.Length == 0 || Patronymic.Length == 0 || Mail.Length == 0 || Combo_Roles1.Text == "")
            {
                MessageBox.Show("Вы не заполнили поле!");
            }
            else
            {
                if (error == false)
                {
                    DB.Employers USERSB = new DB.Employers
                    {
                        Login = Login,
                        Password = Password,
                        FisrstName = FirstName,
                        Email = Mail,
                        SurName = SurName,
                        Patronymic = Patronymic,
                        Role = Role
                    };


                    Connection.Employers.Add(USERSB);

                    int result = Connection.SaveChanges();
                    if (result == 1)
                    {
                        Clear();
                        MessageBox.Show("Пользователь успешно добавлен!");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: Пользователь не добавлен");
                    }

                }
            }
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string Desc = Text_Desc.Text;
            List<DB.Employers> employers = Connection.Employers.ToList();

            DB.Team team = new DB.Team
            {
                TeamID = Connection.Team.Count() + 1,
                Description = Desc,
                NumberOfPeople = List_Team.Items.Count,
                TeamLeader = null
            };

            foreach (DB.Employers Employer in employers)
            {
                foreach (object EmployerInList in List_Team.Items)
                {
                    if (Employer.Login == EmployerInList)
                    {
                        Employer.TeamID = Connection.Team.Count() + 1;
                    }
                }
            }

            Connection.Team.Add(team);

            int result = Connection.SaveChanges();
            if (result == 1)
            {
                MessageBox.Show("Команда успешно создана!");
            }
            else
            {
                MessageBox.Show("Ошибка: Команда не создана");
            }
        }

        private void List_Employers1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List_Employers1.SelectedItem != null)
            {
                object _SelectedEmployer = List_Employers1.SelectedItem;
                List_Team.Items.Add(_SelectedEmployer);
                List_Employers1.Items.Remove(_SelectedEmployer);
            }
        }

        private void List_Team_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List_Employers1.SelectedItem != null)
            {
                object _SelectedEmployer = List_Team.SelectedItem;
                List_Employers1.Items.Add(_SelectedEmployer);
                List_Team.Items.Remove(_SelectedEmployer);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (List_Employers2.SelectedItem == null || List_Team1.SelectedItem == null)
            {
                MessageBox.Show("Вы не выделили одно из полей!");
            }
            else
            {
                List<DB.Employers> employers1 = Connection.Employers.ToList();
                List<DB.Team> team1 = Connection.Team.ToList();
                object team = List_Team1.SelectedItem;
                object employers = List_Employers2.SelectedItem;
                foreach (DB.Team team2 in team1)
                {
                    if (Convert.ToInt32(team) == team2.TeamID)
                    {
                        team2.TeamLeader = (string)employers;
                    }
                }
                foreach(DB.Employers employers2 in employers1)
                {
                    if (employers == employers2.Login)
                    {
                        employers2.TeamID = (int?)team;
                    }
                }

                int result = Connection.SaveChanges();
                if (result == 1)
                {
                    MessageBox.Show("Пользователь успешно добавлен!");
                }
                else
                {
                    MessageBox.Show("Ошибка: Пользователь не добавлен");
                }
                List_Employers2.Items.Clear();
                List_Team1.Items.Clear();
                LoadTeamLeads();
                TeamsWTHLeads();
            }
        }
    }
}
