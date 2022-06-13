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
    /// Логика взаимодействия для TeamLead_Page.xaml
    /// </summary>
    public partial class TeamLead_Page : Page
    {
        public TeamLead_Page()
        {
            InitializeComponent();
            LoadProject();
            LoadTeam();
        }
        DB.NetHammerEntities Connection = new DB.NetHammerEntities();

        private void LoadProject ()
        {
            List<DB.Project> projects = Connection.Project.ToList();
            foreach(DB.Project project in projects)
            {
                if (project.Status == "В ожидании")
                {
                    List_Projects.Items.Add(project.IDProject);
                }
            }
        }
        public void LoadTeam ()
        {
            List<DB.Employers> employers = Connection.Employers.ToList();
            string EmployeLogin = User.UserName;
            foreach (DB.Employers employers1 in employers)
            {
                if (employers1.Login == EmployeLogin)
                {
                    Text_Team.Content = employers1.TeamID;
                }
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTeam();
            object ProjectID = List_Projects.SelectedItem;
            List<DB.Project> projects = Connection.Project.ToList();
            foreach (DB.Project project in projects)
            {
                if ((int?)ProjectID == project.IDProject)
                {
                    Text_Client.Text = "Клиент: " + project.LoginClient;
                    Text_Service.Text = "Услуга: " + project.Service;
                    Text_Desc.Text = project.DescClient;
                }
            }
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object ProjectID = List_Projects.SelectedItem;
            List<DB.Project> projects = Connection.Project.ToList();
            foreach (DB.Project project in projects)
            {
                if ((int?)ProjectID == project.IDProject)
                {
                    project.Status = "В разработке";
                    project.TeamID = (int?)Text_Team.Content;
                }
            }
            int result = Connection.SaveChanges();
            if (result == 1)
            {
                MessageBox.Show("Ваш заказ успешно добавлен в очередь!");
                List_Projects.Items.Clear();
                Text_Client.Text = "";
                Text_Service.Text = "";
                Text_Desc.Text = "";
                LoadProject();
            }
            else
            {
                MessageBox.Show("Ошибка: заказ не добавлен");
            }
        }
    }
}
