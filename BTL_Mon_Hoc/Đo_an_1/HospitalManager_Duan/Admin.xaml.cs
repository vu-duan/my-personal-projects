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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private TaiKhoanService _service = new TaiKhoanService();

        //public TaiKhoan EditedTK { get; set; } = null;   //bài 18

        public Admin()
        {
            InitializeComponent();
        }

        private void Menu1_QuanLyTaiKhoan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu1_DangXuatAdmin_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                MainWindow main1 = new MainWindow();
                main1.ShowDialog();
                this.Close();

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Gọi hàm đổ vào lưới
            FillDataGrid();
        }


        //Xây dựng hàm ĐỂ ĐỔ VÀO LƯỚI
        // Thêm => đổ vào lưới, xóa => đổ vào lưới, sửa => Đổ vào lưới, update => đổ vào lưới
        private void FillDataGrid()
        {
            // bảo service để đổ vào lưới
            TaiKhoanDataGrid.ItemsSource = null;  //Xóa lưới đi để cập nhật DATA mới
            TaiKhoanDataGrid.ItemsSource = _service.GetAllTaiKhoans();
        }

        private void ThemButtonA_Click(object sender, RoutedEventArgs e)
        {   
            if(IDTextBoxA.Text == "")
            {
                MessageBox.Show("Vui lòng nhập TaiKhoanId!");
                IDTextBoxA.Focus();
                return;
            }
            if(MatKhauTextBoxA.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                MatKhauTextBoxA.Focus();
                return;
            }
            if(HoTenTextBoxA.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Họ Tên!");
                HoTenTextBoxA.Focus();
                return;
            }

            if(EmailTextBoxA.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Email!");
                EmailTextBoxA.Focus(); 
                return;
            }
            if(PhanQuyenTextBoxA.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phân quyền!");
                PhanQuyenTextBoxA.Focus();
                return;
            }
            if(TrangThaiTextBoxA.Text == "")
            {
                MessageBox.Show("Vui lòng chọn trạng thái cho tài khoản!");
                TrangThaiTextBoxA.Focus();  
                return;
            }

            TaiKhoan x = new TaiKhoan();    
            x.TaiKhoanId = IDTextBoxA.Text;
            x.MatKhau = MatKhauTextBoxA.Text;
            x.HoTen = HoTenTextBoxA.Text;
            x.EmailAddress = EmailTextBoxA.Text;
            x.Role = int.Parse(PhanQuyenTextBoxA.Text);
            x.TrangThai = int.Parse(TrangThaiTextBoxA.Text);

            _service.AddTK(x);   //thêm

            FillDataGrid();     //Hàm xóa data cũ và cập nhật data mới

            MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            //Xóa data khỏi textbox
            IDTextBoxA.Text = "";
            MatKhauTextBoxA.Text = "";
            HoTenTextBoxA.Text = "";
            EmailTextBoxA.Text = "";
            PhanQuyenTextBoxA.Text = "";
            TrangThaiTextBoxA.Text = "";
        }

        private void XoaButtonA_Click(object sender, RoutedEventArgs e)
        {   
            //22:00 NGÀY 1/6/2026
            TaiKhoan? selected = TaiKhoanDataGrid.SelectedItem as TaiKhoan;
            if(selected == null)  //Nếu chưa chọn dòng mà NHẤN NÚT
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var resultXoa = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(resultXoa == MessageBoxResult.Yes)
            {
                _service.DeleteTK(selected);   //Gọi service để xóa

                FillDataGrid();     //Gọi hàm 

                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                DeleteTextBoxA();

                ThemButtonA.IsEnabled = true;

                
            }

        }

        private void LamTuoiButtonA_Click(object sender, RoutedEventArgs e)
        {
            if(IDTextBoxA.Text == "" && HoTenTextBoxA.Text == "" && EmailTextBoxA.Text == "" && MatKhauTextBoxA.Text == "" && PhanQuyenTextBoxA.Text == "" && TrangThaiTextBoxA.Text == "")
            {
                MessageBox.Show("Không có data để làm tươi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information );
                return;
            }
            var resultLTuoiA = MessageBox.Show("Bạn có muốn xóa data ở các textbox không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if(resultLTuoiA == MessageBoxResult.Yes)
            {
                DeleteTextBoxA();
                ThemButtonA.IsEnabled = true;
            }

        }

        private void SuaButtonA_Click(object sender, RoutedEventArgs e)
        {
            if (TaiKhoanDataGrid.SelectedItem is not TaiKhoan tk)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Cập nhật dữ liệu từ TextBox vào đối tượng 
            //(Muốn cập nhật ô nào thì chỉnh sửa ô đó) - Khóa chính
            tk.MatKhau = MatKhauTextBoxA.Text;
            tk.HoTen = HoTenTextBoxA.Text;
            tk.EmailAddress = EmailTextBoxA.Text;
            tk.Role = int.Parse(PhanQuyenTextBoxA.Text);
            tk.TrangThai = int.Parse(TrangThaiTextBoxA.Text);

            // Gọi service cập nhật DB
            _service.UpdateTK(tk);

            // Nạp lại DataGrid
            FillDataGrid();

            MessageBox.Show("Sửa thành công!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
          
            DeleteTextBoxA();

            ThemButtonA.IsEnabled = true;


        }

        private void TaiKhoanDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TaiKhoanDataGrid.SelectedItem is TaiKhoan tk)
            {
                IDTextBoxA.Text = tk.TaiKhoanId.ToString();
                MatKhauTextBoxA.Text = tk.MatKhau.ToString();
                HoTenTextBoxA.Text = tk.HoTen.ToString();
                EmailTextBoxA.Text = tk.EmailAddress.ToString();
                PhanQuyenTextBoxA.Text = tk.Role.ToString();
                TrangThaiTextBoxA.Text = tk.TrangThai.ToString();
                ////Khi chọn dòng ở table thì button thêm ẩn
                ThemButtonA.IsEnabled = false;  
            }
        }

        private void DeleteTextBoxA()
        {
            IDTextBoxA.Text = "";
            MatKhauTextBoxA.Text = "";
            HoTenTextBoxA.Text = "";
            EmailTextBoxA.Text = "";
            PhanQuyenTextBoxA.Text = "";
            TrangThaiTextBoxA.Text = "";
        }


        


    }
}
