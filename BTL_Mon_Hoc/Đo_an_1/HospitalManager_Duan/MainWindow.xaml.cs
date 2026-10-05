using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalManager_Duan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Menu1_ĐangKy_Click(object sender, RoutedEventArgs e)
        {
            DangKy dangKy = new DangKy();
            this.Hide();
            dangKy.ShowDialog();
            this.Show();

        }

        private void Menu1_DangNhap_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            this.Hide();
            dangNhap.ShowDialog();
            this.Show();
        }

        private void Menu2_TrangChu_Click(object sender, RoutedEventArgs e)
        {

            lblTrangChuMainWindow.Content = "     Trang chủ";
            MainContent.Content = new UC_TrangChu();
        }

        private void Menu2_GioiThieu_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuMainWindow.Content = "     Giới thiệu";
            MainContent.Content = new UC_GioiThieu();
        }

        
        /*
        private void Menu2_ChuyenKhoa_Click(object sender, RoutedEventArgs e)
        {

        }
        */


        private void KhoaMatMw_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuMainWindow.Content = "     Chuyên khoa > Khoa mắt";
            MainContent.Content = new UC_KhoaMat();
        }

        private void KhoaHoHapMw_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuMainWindow.Content = "     Chuyên khoa > Khoa hô hấp";
            MainContent.Content = new UC_KhoaHoHap();
        }

        private void KhoaTimMachMw_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuMainWindow.Content = "     Chuyên khoa > Khoa tim mạch";
            MainContent.Content = new UC_KhoaTimMach();
        }

        private void KhoaCapCuuMw_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuMainWindow.Content = "     Chuyên khoa > Khoa cấp cứu";
            MainContent.Content = new UC_KhoaCapCuu();  
        }



        private void Menu2_TinTuc_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuMainWindow.Content = "     Tin tức";
            MainContent.Content = new UC_TinTuc();
        }

        private void Menu2_LienHe_Click(object sender, RoutedEventArgs e)
        {
            lblTrangChuMainWindow.Content = "     Liên hệ";
            MainContent.Content = new UC_LienHe();
        }

        
    }
}