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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalManager_Duan
{
    /// <summary>
    /// Interaction logic for UC_QuanLyKhoaBenh.xaml
    /// </summary>
    public partial class UC_QuanLyKhoaBenh : UserControl
    {   
        //Tại GUI Gọi service
        private KhoaBenhService _service1 = new KhoaBenhService();

        public UC_QuanLyKhoaBenh()
        {
            InitializeComponent();
        }

        private void SuaBtnQLKB_Click(object sender, RoutedEventArgs e)
        {   
            if(MaKhoaTextBoxQLKB.Text == "" && TenKhoaTextBoxQLKB.Text == "" && DiaChiKhoaTxtBoxQLKB.Text == "")
            {
                MessageBox.Show("Vui Lòng lựa chọn khoa bệnh để chỉnh sửa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            
            if(KhoaBenhDataGridQLKB.SelectedItem is not KhoaBenh kB)
            {
                MessageBox.Show("Vui lòng lựa chọn khoa bệnh để chỉnh sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            
            // Cập nhật dữ liệu từ TextBox vào đối tượng
            kB.DiaChiKhoa = DiaChiKhoaTxtBoxQLKB.Text;

            //Gọi server để update
            _service1.UpdateKBenh(kB);
            // Nạp lại DataGrid
            FillDataGrid();
            //Thông báo
            MessageBox.Show("Chỉnh sửa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            DeleteTextBoxQLKB();

            //Hiện Button Thêm
            ThemKhoaBtnQLKB.IsEnabled = true;


        }

        private void LamTuoiBtnQLKB_Click(object sender, RoutedEventArgs e)
        {
            if(MaKhoaTextBoxQLKB.Text == "" && TenKhoaTextBoxQLKB.Text == "" && DiaChiKhoaTxtBoxQLKB.Text == "")
            {
                MessageBox.Show("Không có data để làm tươi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var resultLamTuoiQLKB = MessageBox.Show("Bạn có muốn làm tươi không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(resultLamTuoiQLKB ==  MessageBoxResult.Yes)
            {
                DeleteTextBoxQLKB();
                ThemKhoaBtnQLKB.IsEnabled = true;
            
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        // Hàm đổ vào lưới khi dùng thêm, xóa, update
        private void FillDataGrid()
        {
            KhoaBenhDataGridQLKB.ItemsSource = null; //Xóa data ở dataGrid 
            KhoaBenhDataGridQLKB.ItemsSource = _service1.GetAllKhoaBenh(); // Đổ data vào DataGrid
        }

        private void ThemKhoaBtnQLKB_Click(object sender, RoutedEventArgs e)
        {
            if(MaKhoaTextBoxQLKB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã Khoa !", "Thông báo");
                MaKhoaTextBoxQLKB.Focus();
                return;
            }
            if(TenKhoaTextBoxQLKB.Text == "")
            {
                MessageBox.Show("Vui lòng điền tên khoa !", "Thông báo");
                TenKhoaTextBoxQLKB.Focus();
                return;

            }
            if(DiaChiKhoaTxtBoxQLKB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ !", "Thông báo");
                DiaChiKhoaTxtBoxQLKB.Focus();
                return;
            }
            KhoaBenh x = new KhoaBenh();
            x.MaKhoa = MaKhoaTextBoxQLKB.Text;
            x.TenKhoa = TenKhoaTextBoxQLKB.Text;
            x.DiaChiKhoa = DiaChiKhoaTxtBoxQLKB.Text;

            _service1.AddKBenh(x);

            FillDataGrid();

            MessageBox.Show("Thêm khoa bệnh thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            /*
            MaKhoaTextBoxQLKB.Text = "";
            TenKhoaTextBoxQLKB.Text = "";
            DiaChiKhoaTxtBoxQLKB.Text = "";
            */
            DeleteTextBoxQLKB();


        }

        private void KhoaBenhDataGridQLKB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(KhoaBenhDataGridQLKB.SelectedItem is KhoaBenh kb)
            {
                MaKhoaTextBoxQLKB.Text = kb.MaKhoa.ToString();
                TenKhoaTextBoxQLKB.Text = kb.TenKhoa.ToString();
                DiaChiKhoaTxtBoxQLKB.Text = kb.DiaChiKhoa.ToString();
                // ẩn Button Thêm, Khi dòng dữ liệu row đổ data vào textbox.Tránh khóa chính
                ThemKhoaBtnQLKB.IsEnabled = false;
            }
        }

        //Hàm xóa data ở Các textbox
        private void DeleteTextBoxQLKB()
        {
            MaKhoaTextBoxQLKB.Text = "";
            TenKhoaTextBoxQLKB.Text = "";
            DiaChiKhoaTxtBoxQLKB.Text = "";

        }


    }
}
