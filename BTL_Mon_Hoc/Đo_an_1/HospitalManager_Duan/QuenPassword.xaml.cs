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
using System.Windows.Shapes;

namespace HospitalManager_Duan
{
    /// <summary>
    /// Interaction logic for QuenPassword.xaml
    /// </summary>
    public partial class QuenPassword : Window
    {
        public QuenPassword()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click2(object sender, RoutedEventArgs e)
        {
            DangNhap dangNhap2 = new DangNhap();
            this.Hide();
            dangNhap2.ShowDialog();
            //this.Show();
        }
    }
}
