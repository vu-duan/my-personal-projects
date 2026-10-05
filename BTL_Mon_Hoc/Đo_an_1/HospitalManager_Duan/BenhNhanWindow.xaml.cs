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
    /// Interaction logic for BenhNhan.xaml
    /// </summary>
    public partial class BenhNhanWindow : Window
    {
        public BenhNhanWindow()
        {
            InitializeComponent();
        }

        private void Menu1_DangXuat2_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                MainWindow main1 = new MainWindow();
                main1.ShowDialog();
                this.Close();

            }
        }

        private void Menu2_GioiThieu2_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuBenhNhan.Content = "     Giới thiệu";
            MainContent.Content = new UC_GioiThieu();
        }
        /*
        private void Menu2_DichVu2_Click(object sender, RoutedEventArgs e)
        {

        }
        */

        /*
        private void Menu2_ChuyenKhoa2_Click(object sender, RoutedEventArgs e)
        {

        }
        */

        private void Menu2_TinTuc2_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuBenhNhan.Content = "     Tin tức";
            MainContent.Content = new UC_TinTuc();
            
        }

        private void Menu2_LienHe2_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuBenhNhan.Content = "     Liên hệ";
            MainContent.Content = new UC_LienHe();
        }

        private void Menu2_TrangChu2_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuBenhNhan.Content = "     Trang chủ";
            MainContent.Content = new UC_TrangChu();
        }

        private void KhoaMatBenhNhan_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuBenhNhan.Content = "     Chuyên khoa > Khoa mắt";
            MainContent.Content = new UC_KhoaMat();
        }

        private void KhoaHoHapBenhNhan_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuBenhNhan.Content = "     Chuyên khoa > Khoa hô hấp";
            MainContent.Content = new UC_KhoaHoHap();
        }

        private void KhoaTimMachBenhNhan_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuBenhNhan.Content = "     Chuyên khoa > Khoa tim mạch";
            MainContent.Content = new UC_KhoaTimMach();
        }

        private void KhoaCapCuuBenhNhan_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuBenhNhan.Content = "     Chuyên khoa > Khoa cấp cứu";
            MainContent.Content = new UC_KhoaCapCuu();
        }

        private void DatLichKham2_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuBenhNhan.Content = "     Dịch vụ > Đặt lịch khám";
            MainContent.Content = new UC_DatLichKham();
        }

        private void LichSuKhamBenh2_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuBenhNhan.Content = "     Dịch vụ > Lịch sử khám bệnh";
            MainContent.Content = new UC_LichSuKhamBenh();
        }

        private void DienThongTinCaNhan2_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuBenhNhan.Content = "     Dịch vụ > Điền Thông tin cá nhân";
            MainContent.Content = new UC_DienTTBenhNhan();
        }
    }
}
