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
    /// Interaction logic for UC_TTBacSi.xaml
    /// </summary>
    public partial class UC_TTBacSi : UserControl
    {   
        private BacSiService _service = new BacSiService();

        public UC_TTBacSi()
        {
            InitializeComponent();
        }

        private void LuuBtnTTBs_Click(object sender, RoutedEventArgs e)
        {
            if(MaKhoaComboBoxTTBs.Text == "")
            {
                MessageBox.Show("Vui lòng lựa chọn mã khoa !", "Thông báo");
                MaKhoaComboBoxTTBs.Focus();
                return;
            }
            if(CccdTBoxTTBs.Text == "")
            {
                MessageBox.Show("Vui lòng nhập căn cưới công dân!", "Thông báo");
                CccdTBoxTTBs.Focus();
                return;

            }
            if(HoTenTBoxTTBs.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên !", "Thông báo");
                HoTenTBoxTTBs.Focus();
                return;
            }
            if(NamSinhTBoxTTBs.Text == "")
            {
                MessageBox.Show("Vui lòng nhập năm sinh!", "Thông báo");
                NamSinhTBoxTTBs.Focus();
                return;
            }
            if (SdtTBoxTTBs.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại !", "Thông báo");
                SdtTBoxTTBs.Focus();
                return;
            }
            if(GioiTinhComboBoxTTBs.Text == "")
            {
                MessageBox.Show("Vui lòng lựa chọn giới tính !", "Thông báo");
                GioiTinhComboBoxTTBs.Focus();
                return;
            }
            if(ChucVuComboBoxTTBs.Text == "")
            {
                MessageBox.Show("Vui lòng lựa chọn chức vụ!", "Thông báo");
                ChucVuComboBoxTTBs.Focus();
                return;
            }
            BacSi x = new BacSi();
            x.MaKhoa = MaKhoaComboBoxTTBs.Text;
            x.MaBacSi = CccdTBoxTTBs.Text;
            x.TenBacSi = HoTenTBoxTTBs.Text;
            x.NamSinh = NamSinhTBoxTTBs.Text;
            x.Phone = SdtTBoxTTBs.Text;
            x.GioiTinh = GioiTinhComboBoxTTBs.Text;
            x.ChucVu = ChucVuComboBoxTTBs.Text;

            _service.AddBs(x);

            MessageBox.Show("Lưu thông tin bác sĩ thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            DeleteTextBoxTTBs();

        }

        //Làm tươi
        private void LamTuoiBtnTTBs_Click(object sender, RoutedEventArgs e)
        {
            if(MaKhoaComboBoxTTBs.Text == "" && CccdTBoxTTBs.Text == "" && HoTenTBoxTTBs.Text == "" &&NamSinhTBoxTTBs.Text == ""
            && SdtTBoxTTBs.Text == "" && GioiTinhComboBoxTTBs.Text == "" && ChucVuComboBoxTTBs.Text == "" && MaBacSiTBoxTTBs.Text == "" && ThongTinBacSiDataGird.ItemsSource == null)
            {
                MessageBox.Show("Không có data để làm tươi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var result = MessageBox.Show("Bạn có chắc chắn muốn làm tươi không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DeleteTextBoxTTBs();
                MaBacSiTBoxTTBs.Text = "";
                ThongTinBacSiDataGird.ItemsSource = null;
                LuuBtnTTBs.IsEnabled = true;
            }

        }

        private void TraCuuBtnTTBs_Click(object sender, RoutedEventArgs e)
        {
            string maBs = MaBacSiTBoxTTBs.Text.Trim();
            if (string.IsNullOrEmpty(maBs))
            {
                MessageBox.Show("Vui lòng nhập căn cước công dân để tra cứu thông tin cá nhân", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                MaBacSiTBoxTTBs.Focus();
                return;
            }
            var bSx = _service.SearchBacSiByMaBacSi(maBs);  
            if(bSx.Count == 0)
            {
                MessageBox.Show("Vui lòng kiểm tra lại căn cước công dân", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                MaBacSiTBoxTTBs.Focus();
                return;
            }
            //Đổ data lên datagird nếu tìm thấy
            ThongTinBacSiDataGird.ItemsSource = bSx;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ThongTinBacSiDataGird.ItemsSource = null;
        }

        private void ThongTinBacSiDataGird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ThongTinBacSiDataGird.SelectedItem is BacSi bSi)
            {
                MaKhoaComboBoxTTBs.Text = bSi.MaKhoa;
                CccdTBoxTTBs.Text = bSi.MaBacSi;
                HoTenTBoxTTBs.Text = bSi.TenBacSi;
                NamSinhTBoxTTBs.Text = bSi.NamSinh;
                SdtTBoxTTBs.Text = bSi.Phone;
                GioiTinhComboBoxTTBs.Text = bSi.GioiTinh;
                ChucVuComboBoxTTBs.Text = bSi.ChucVu;
                //ẩn chức năng của button "Lưu"
                LuuBtnTTBs.IsEnabled = false;
            }
        }

        private void ChinhSuaBtnTTBs_Click(object sender, RoutedEventArgs e)
        {
            if(ThongTinBacSiDataGird.SelectedItem is not BacSi ttbs)
            {
                MessageBox.Show("Vui lòng tra cứu thông tin cá nhân để chỉnh sửa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                MaBacSiTBoxTTBs.Focus();
                return;
            }
            //cập nhật dữ liệu từ các ô textbox muốn sửa
            //- ô khoa chính
            ttbs.TenBacSi = HoTenTBoxTTBs.Text;
            ttbs.NamSinh = NamSinhTBoxTTBs.Text;
            ttbs.Phone = SdtTBoxTTBs.Text;
            ttbs.GioiTinh = GioiTinhComboBoxTTBs.Text;
            ttbs.ChucVu = ChucVuComboBoxTTBs.Text;

            _service.UpdateTTBsi(ttbs);

            //ThongTinBacSiDataGird.ItemsSource;

            MessageBox.Show("Chỉnh sửa thông tin cá nhân thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            DeleteTextBoxTTBs();
            MaBacSiTBoxTTBs.Text = "";
            ThongTinBacSiDataGird.ItemsSource = null;

            LuuBtnTTBs.IsEnabled = true;

        }

        //Hàm xóa data ở text box
        private void DeleteTextBoxTTBs()    //6/3
        {
            MaKhoaComboBoxTTBs.Text = "";
            CccdTBoxTTBs.Text = "";
            HoTenTBoxTTBs.Text = "";
            NamSinhTBoxTTBs.Text = "";
            SdtTBoxTTBs.Text = "";
            GioiTinhComboBoxTTBs.Text = "";
            ChucVuComboBoxTTBs.Text = "";
        }

    }
}
