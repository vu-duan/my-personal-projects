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
    /// Interaction logic for UC_DienTTBenhNhan.xaml
    /// </summary>
    public partial class UC_DienTTBenhNhan : UserControl
    {
        private BenhNhanService _service = new BenhNhanService();

        public UC_DienTTBenhNhan()
        {
            InitializeComponent();
        }

        //Button "Thêm Mới"
        private void LuuBtnTT_Click(object sender, RoutedEventArgs e)
        {
            if(CccdTxtBoxTT.Text == "")
            {
                MessageBox.Show("Vui lòng điền Căn cước công dân của bạn!", "Thông báo");
                CccdTxtBoxTT.Focus();
                return;
            }
            if(HoTenTxtBoxTT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo");
                HoTenTxtBoxTT.Focus();  
                return;
            }
            if(NamSinhTxtBoxTT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập năm sinh!", "Thông báo");
                NamSinhTxtBoxTT.Focus();
                return;
            }
            if(GioiTinhComboBoxTT.Text == "")
            {
                MessageBox.Show("Vui lòng lựa chọn giới tính", "Thông báo");
                GioiTinhComboBoxTT.Focus(); 
                return;
            }
            if(DiaChiTxtBoxTT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ !", "Thông báo");
                DiaChiTxtBoxTT.Focus();
                return;
            }
            if(PhoneTxtBoxTT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số Phone của bạn!", "Thông báo");
                PhoneTxtBoxTT.Focus();
                return;
            }
            
            BenhNhan x = new BenhNhan();
            x.MaBenhNhan = CccdTxtBoxTT.Text;
            x.TenBenhNhan = HoTenTxtBoxTT.Text;
            x.NamSinh = NamSinhTxtBoxTT.Text;
            x.GioiTinh = GioiTinhComboBoxTT.Text;
            x.DiaChi = DiaChiTxtBoxTT.Text;
            x.Phone = PhoneTxtBoxTT.Text;

            _service.AddBenhNhan(x);

            MessageBox.Show("Lưu thông tin bệnh nhân thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            DeleteTxtBoxTTBN();
           
        }

        private void LamTuoiBtnTT_Click(object sender, RoutedEventArgs e)
        {
           if(CccdTxtBoxTT.Text == "" && HoTenTxtBoxTT.Text == "" && NamSinhTxtBoxTT.Text == "" && GioiTinhComboBoxTT.Text == "" && DiaChiTxtBoxTT.Text == "" && PhoneTxtBoxTT.Text == "" && SreachCccdTxt.Text == "" && ThongTinBenhNhanDataGirdTT.ItemsSource == null)
            {
                MessageBox.Show("Không có data để làm tươi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
           var resultTTBN = MessageBox.Show("Bạn có muốn xóa data ở các ô nhập không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(resultTTBN == MessageBoxResult.Yes)
            {
                DeleteTxtBoxTTBN();
                SreachCccdTxt.Text = "";//
                ThongTinBenhNhanDataGirdTT.ItemsSource = null;//
                LuuBtnTT.IsEnabled = true;  //Khôi phục trạng thái button
            }
        }

        //Hàm xóa xóa data ở textbox và combobox
        private void DeleteTxtBoxTTBN()
        {
            CccdTxtBoxTT.Text = "";
            HoTenTxtBoxTT.Text = "";
            NamSinhTxtBoxTT.Text = "";
            GioiTinhComboBoxTT.Text = "";
            DiaChiTxtBoxTT.Text = "";
            PhoneTxtBoxTT.Text = "";
        }

        //Button "Tra cứu"
        private void TraCuuBtnTT_Click(object sender, RoutedEventArgs e)
        {
            string maCccd = SreachCccdTxt.Text.Trim();
            if(string.IsNullOrEmpty(maCccd) )
            {
                MessageBox.Show("Vui lòng nhập căn cước công dân của bạn để tra cứu thông tin của bạn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                SreachCccdTxt.Focus();//
                return;
            }
            var ttBNx = _service.RearchTTBenhNhanByCccd(maCccd);
            if(ttBNx.Count == 0)
            {
                MessageBox.Show("Vui lòng kiểm tra lại số căn cước công dân của bạn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                SreachCccdTxt.Focus();
                return;
            }
            //Fill data lên datagrid nếu tìm thấy 
            ThongTinBenhNhanDataGirdTT.ItemsSource = ttBNx;


        }

        private void SuaBtnTT_Click(object sender, RoutedEventArgs e)
        {
            if(ThongTinBenhNhanDataGirdTT.SelectedItem is not BenhNhan ttBNhan)
            {
                MessageBox.Show("Vui lòng tra cứu thông tin của bạn để chỉnh sửa thông tin cá nhân!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            //Cập nhật data từ các ô textbox vào đối tươngj
            //cập nhật chỉnh sửa trừ Ô khóa chính
            ttBNhan.TenBenhNhan = HoTenTxtBoxTT.Text;
            ttBNhan.NamSinh = NamSinhTxtBoxTT.Text;
            ttBNhan.GioiTinh = GioiTinhComboBoxTT.Text;
            ttBNhan.DiaChi = DiaChiTxtBoxTT.Text;
            ttBNhan.Phone = PhoneTxtBoxTT.Text;
            //Gọi service để cập nhật
            _service.UpdateTTBenhNhan(ttBNhan);
            //
            MessageBox.Show("Chỉnh sửa thông tin các nhân thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            DeleteTxtBoxTTBN();
            SreachCccdTxt.Text = "";
            ThongTinBenhNhanDataGirdTT.ItemsSource = null;
            LuuBtnTT.IsEnabled = true;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ThongTinBenhNhanDataGirdTT.ItemsSource = null;
        }

        private void ThongTinBenhNhanDataGirdTT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ThongTinBenhNhanDataGirdTT.SelectedItem is BenhNhan ttbNhan)
            {
                CccdTxtBoxTT.Text = ttbNhan.MaBenhNhan;
                HoTenTxtBoxTT.Text = ttbNhan.TenBenhNhan;
                NamSinhTxtBoxTT.Text = ttbNhan.NamSinh;
                GioiTinhComboBoxTT.Text = ttbNhan.GioiTinh;
                DiaChiTxtBoxTT.Text = ttbNhan.DiaChi;
                PhoneTxtBoxTT.Text = ttbNhan.Phone;
                LuuBtnTT.IsEnabled = false;  //ẩn chức năng của button "Thêm mới" tránh PK
            }
        }
    }
}
