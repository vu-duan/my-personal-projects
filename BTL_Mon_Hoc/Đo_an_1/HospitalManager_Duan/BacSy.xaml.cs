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
    /// Interaction logic for BacSy.xaml
    /// </summary>
    public partial class BacSy : Window
    {
        public BacSy()
        {
            InitializeComponent();
        }

        private void Menu1_QuanLyBenhNhan_Click(object sender, RoutedEventArgs e)
        {
            lblHienThiBacSi.Content = "     Quản lý bệnh nhân";
            MainContent.Content = new UC_QuanLyBenhNhan();
        }

        private void Menu1_LichLamViec_Click(object sender, RoutedEventArgs e)
        {
            lblHienThiBacSi.Content = "     Lịch làm việc";
            MainContent.Content = new UC_LichLamViecBacSi();
        }

        private void Menu1_DangXuatBS_Click(object sender, RoutedEventArgs e)
        {
            var resultBS = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultBS == MessageBoxResult.Yes)
            {
                MainWindow main2 = new MainWindow();
                main2.ShowDialog();
                this.Close();
            }
        }

        private void Menu1_NhapKetQua_Click(object sender, RoutedEventArgs e)
        {
            lblHienThiBacSi.Content = "     Nhập kết quả";
            MainContent.Content = new UC_NhapKetQua();
        }

        private void Menu1_ThongTinCaNhan_Click(object sender, RoutedEventArgs e)
        {
            lblHienThiBacSi.Content = "     Thông tin cá nhân";
            MainContent.Content = new UC_TTBacSi();
        }
    }
}
