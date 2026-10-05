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
    /// Interaction logic for DangKy.xaml
    /// </summary>
    public partial class DangKy : Window
    {
        private TaiKhoanService _service = new TaiKhoanService();

        public DangKy()
        {
            InitializeComponent();
        }
        private void Hyperlink_Click1(object sender, RoutedEventArgs e)
        {
            DangNhap dangNhap1 = new DangNhap();
            this.Hide();
            dangNhap1.ShowDialog();
            //this.Show();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(CccdTextBoxDKy.Text == "")
            {
                MessageBox.Show("Vui lòng nhập căn cước công dân của bạn !", "Thông báo");
                CccdTextBoxDKy.Focus();
                return;
            }
            if(HoTenTextBoxDKy.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên !", "Thông báo");
                HoTenTextBoxDKy.Focus(); 
                return;
            }
            if(EmailTextBoxDKy.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email !", "Thông báo");
                EmailTextBoxDKy.Focus();
                return;
            }
            if(PasswordTextBoxDKy.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu !", "Thông báo");
                PasswordTextBoxDKy.Focus();
                return;
            }
            if(Password2TextBoxDKy.Text == "")
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu !", "Thông báo");
                Password2TextBoxDKy.Focus();
                return;
            }
            if(PasswordTextBoxDKy.Text != Password2TextBoxDKy.Text)
            {
                MessageBox.Show("Vui lòng kiểm tra password2 !", "Thông báo");
                Password2TextBoxDKy.Focus();
                return;
            }

            //Gọi service để lưu data xuống table database
            //TaiKhoan y = new TaiKhoan();
            TaiKhoan y = new TaiKhoan();
            y.TaiKhoanId = CccdTextBoxDKy.Text;
            y.MatKhau = PasswordTextBoxDKy.Text;
            y.HoTen = HoTenTextBoxDKy.Text;
            y.EmailAddress = EmailTextBoxDKy.Text;
            y.Role = int.Parse("1");
            y.TrangThai = int.Parse("1");

            _service.AddTK(y);

            MessageBox.Show("Đăng ký thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            CccdTextBoxDKy.Text = "";
            HoTenTextBoxDKy.Text = "";
            EmailTextBoxDKy.Text = "";
            PasswordTextBoxDKy.Text = "";
            Password2TextBoxDKy.Text = "";


        }


    }
}
