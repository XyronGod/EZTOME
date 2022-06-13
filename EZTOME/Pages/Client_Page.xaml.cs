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
    /// Логика взаимодействия для Client_Page.xaml
    /// </summary>
    public partial class Client_Page : Page
    {
        public Client_Page()
        {
            InitializeComponent();
            LoadServices();
        }
        DB.NetHammerEntities Connection = new DB.NetHammerEntities();
        private void LoadServices ()
        {
            List<DB.Services> services = Connection.Services.ToList();
            foreach (DB.Services services1 in services)
            {
                Combo_Services.Items.Add(services1.Name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int IDProject = Connection.Project.Count() + 1;
            DB.Project project = new DB.Project
            {
                IDProject = IDProject,
                LoginClient = User.UserName,
                TeamID = null,
                Status = "В ожидании",
                Service = Combo_Services.Text,
                DescClient = Text_Desc.Text
            };
            Connection.Project.Add(project);
            int result = Connection.SaveChanges();
            if (result == 1)
            {
                MessageBox.Show("Ваш заказ успешно добавлен в очередь!");
            }
            else
            {
                MessageBox.Show("Ошибка: заказ не добавлен");
            }
        }

        

        private void Combo_Services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<DB.Services> services = Connection.Services.ToList();
            object Service = Combo_Services.SelectedItem;

            foreach (DB.Services services1 in services)
            {
                if (Service == services1.Name)
                {
                    Text_Desc1.Text = services1.Description;
                    Label_Price.Content = "Цена: " + (int)services1.price + " Руб.";
                }
            }
        }
    }
}
