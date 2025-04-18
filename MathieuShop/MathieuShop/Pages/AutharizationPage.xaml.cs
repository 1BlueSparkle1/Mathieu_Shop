using MathieuShop.Components;
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

namespace MathieuShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutharizationPage.xaml
    /// </summary>
    public partial class AutharizationPage : Page
    {
        public AutharizationPage()
        {
            InitializeComponent();
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<User> users = App.db.User.ToList();
            if (!string.IsNullOrEmpty(LoginTb.Text) && !string.IsNullOrEmpty(PasswordTb.Text))
            {
                foreach (User user in users)
                {
                    if (user.Login == LoginTb.Text)
                    {
                        if (user.Password == PasswordTb.Text)
                        {
                            App.thisUser = user;
                            Navigations.NextPage(new ListServicePage());
                            break;
                        }
                    }
                }
                if (App.thisUser.Id == 0)
                {
                    MessageBox.Show("Пользователь не найден!");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
        }
    }
}
