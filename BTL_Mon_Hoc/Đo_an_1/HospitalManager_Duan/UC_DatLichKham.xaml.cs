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
    /// Interaction logic for UC_DatLichKham.xaml
    /// </summary>
    public partial class UC_DatLichKham : UserControl
    {   
        private PhieuKhamBenhService _service = new PhieuKhamBenhService();

        public UC_DatLichKham()
        {
            InitializeComponent();
        }

        private void ButtonLamTuoiDLK_Click(object sender, RoutedEventArgs e)
        {   
            /*
            var resultLTuoi = MessageBox.Show("Bạn có muốn làm tươi không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultLTuoi == MessageBoxResult.Yes)
            {   
                if(TextBoxMaBenhNhanDLK.Text == "" && TextBoxNgayKhamDLK.Text == "" && TextBoxTrieuChungDLK.Text == "" && ComboBoxBuoiDLK.Text == "" && ComboBoxKhoaBenhDLK.Text == "")
                {
                    MessageBox.Show("Không có dữ liệu để làm tươi!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    TextBoxMaBenhNhanDLK.Text = "";
                    ComboBoxBuoiDLK.Text = "";
                    TextBoxNgayKhamDLK.Text = "";
                    ComboBoxKhoaBenhDLK.Text = "";
                    TextBoxTrieuChungDLK.Text = "";
                }
                   

            }
            */
           
            if (TextBoxMaBenhNhanDLK.Text == "" && TextBoxNgayKhamDLK.Text == "" && TextBoxTrieuChungDLK.Text == "" && ComboBoxBuoiDLK.Text == "" && ComboBoxKhoaBenhDLK.Text == "")
            {
                MessageBox.Show("Không có dữ liệu để làm tươi!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
             }
             else
             {
                var resultLTuoi = MessageBox.Show("Bạn có muốn làm tươi không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultLTuoi == MessageBoxResult.Yes)
                {
                    TextBoxMaBenhNhanDLK.Text = "";
                    ComboBoxBuoiDLK.Text = "";
                    TextBoxNgayKhamDLK.Text = "";
                    ComboBoxKhoaBenhDLK.Text = "";
                    TextBoxTrieuChungDLK.Text = "";
                }    
                   
             }

        }

        private void ButtonDatLichKhamDLK_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxMaBenhNhanDLK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã bệnh nhân!", "Thông báo");
                TextBoxMaBenhNhanDLK.Focus();
                return;
            }
            if(ComboBoxBuoiDLK.Text == "")
            {
                MessageBox.Show("Vui lòng lựa chọn buổi khám!", "Thông báo");
                ComboBoxBuoiDLK.Focus();
                return;
            }
            if(TextBoxNgayKhamDLK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ngày khám theo dd/mm/yyyy !", "Thông báo");
                TextBoxNgayKhamDLK.Focus();
                return;
            }
            if(ComboBoxKhoaBenhDLK.Text == "")
            {
                MessageBox.Show("Vui lòng lựa chọn khoa bệnh!", "Thông báo");
                ComboBoxKhoaBenhDLK.Focus();
                return;
            }
            if(TextBoxTrieuChungDLK.Text == "")
            {
                MessageBox.Show("Triệu chứng bệnh của bạn!", "Thông báo");
                TextBoxTrieuChungDLK.Focus();
                return;
            }
            
            PhieuKhamBenh x = new PhieuKhamBenh();
            x.MaBenhNhan = TextBoxMaBenhNhanDLK.Text;
            x.Buoi = ComboBoxBuoiDLK.Text;
            x.NgayKham = TextBoxNgayKhamDLK.Text;
            x.TenKhoa = ComboBoxKhoaBenhDLK.Text;  
            x.TrieuChung = TextBoxTrieuChungDLK.Text;
            x.BacSi = "Null";
            x.KetQua = "Null";

            _service.AddPhieuKham(x);

            MessageBox.Show("Đặt lịch khám thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            TextBoxMaBenhNhanDLK.Text = "";
            ComboBoxBuoiDLK.Text = "";
            TextBoxNgayKhamDLK.Text = "";
            ComboBoxKhoaBenhDLK.Text = "";
            TextBoxTrieuChungDLK.Text = "";

        }

    }
}
