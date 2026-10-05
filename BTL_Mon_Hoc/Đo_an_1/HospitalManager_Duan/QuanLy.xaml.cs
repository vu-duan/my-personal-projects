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
    /// Interaction logic for QuanLy.xaml
    /// </summary>
    public partial class QuanLy : Window
    {
        public QuanLy()
        {
            InitializeComponent();
        }

        private void Menu1_QuanLyBacSi_Click(object sender, RoutedEventArgs e)
        {
            lblHienThiQuanLy.Content = "     Quản lý bác sĩ";
            MainContent.Content = new UC_QuanLyBacSi();
        }

        private void Menu1_QuanLyKhoaBenh_Click(object sender, RoutedEventArgs e)
        {
            lblHienThiQuanLy.Content = "     Quản lý khoa bệnh";
            MainContent.Content = new UC_QuanLyKhoaBenh();
        }

        private void Menu1_DangXuatQL_Click(object sender, RoutedEventArgs e)
        {
            var result1 = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result1 == MessageBoxResult.Yes)
            {
                MainWindow main1 = new MainWindow();
                main1.ShowDialog();
                this.Close();
            }
        }
    }
}
