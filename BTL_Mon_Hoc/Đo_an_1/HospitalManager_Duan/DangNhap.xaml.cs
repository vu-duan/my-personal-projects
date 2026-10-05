using HospitalManager.BLL.Services;
using HospitalManager.DAL.Entities;
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
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {   
        private TaiKhoanService _taiKhoanService = new TaiKhoanService();


        public DangNhap()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            QuenPassword quenMK = new QuenPassword();
            this.Hide();
            quenMK.ShowDialog();
            //this.Show();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            if(EmailAddressTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email của bạn để đăng nhâp!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if(MatKhauTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu để đăng nhập!");
                return;
            }
            //Phải login thành công thì mới được show
            TaiKhoan account = _taiKhoanService.Authenticate(EmailAddressTextBox.Text, MatKhauTextBox.Text);
            //1. account này có thể null
            if(account == null)
            {
                MessageBox.Show("Email hoặc Password bị sai. Vui Lòng kiểm tra lại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //2. account là 1 dòng tài khoản nào đó thuộc role 1, 2 , 3, 4 , cx có thể khác null(login thành công)
            //if(account.Role == 1)   Bệnh nhân
            //if(account.Role == 2)  admin
            //if(account.Role == 3)   quan lý
            //if(account.Role == 4)   bác sĩ

            //if(account.Role == 2)  admin
            if (account.Role == 2 && account.TrangThai == 0)
            {
                MessageBox.Show("Tài khoản này đã dừng hoạt động!", "Thông báo", MessageBoxButton.OK);
                return;
            }
            if (account.Role == 2 && account.TrangThai == 1)
            {
                /*
                MessageBox.Show("Tài khoản admin!", "Thông báo", MessageBoxButton.OK);
                return;
                */

                this.Hide();
                Admin ad = new Admin();
                ad.ShowDialog();
                
                
            }

            //if(account.Role == 1)   Bệnh nhân
            if (account.Role == 1 && account.TrangThai == 0)
            {
                MessageBox.Show("Tài khoản người dùng bệnh nhân này đã dừng hoạt động. Vui lòng liên hệ admin để hoạt động trở lại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (account.Role == 1 && account.TrangThai == 1)
            {
                BenhNhanWindow bNhan = new BenhNhanWindow();
                this.Hide();
                bNhan.ShowDialog();
            }

            //if(account.Role == 3)   quản lý
            if(account.Role == 3 && account.TrangThai == 0)
            {
                MessageBox.Show("Tài khoản người dùng quản lý này đã dừng hoạt động!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if(account.Role == 3 && account.TrangThai == 1)
            {
                this.Hide();
                QuanLy qly = new QuanLy();
                qly.ShowDialog();
            }

            //if(account.Role == 4)   bác sĩ
            if(account.Role == 4 && account.TrangThai == 0)
            {
                MessageBox.Show("Tài khoản người dùng bác sĩ này của bạn đã dừng hoạt động!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (account.Role == 4 && account.TrangThai == 1)
            {
                this.Hide();
                BacSy bsy = new BacSy();
                bsy.ShowDialog();
                //MessageBox.Show("Tài khoản bác sĩ");
                //return;
            }







            /*
            MainWindow m = new MainWindow();
            m.Show();
            m.Hide();
            */
        }
    }
}
