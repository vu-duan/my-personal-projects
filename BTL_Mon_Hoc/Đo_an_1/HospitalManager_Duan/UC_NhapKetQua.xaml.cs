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
    /// Interaction logic for UC_NhapKetQua.xaml
    /// </summary>
    public partial class UC_NhapKetQua : UserControl
    { 
        private PhieuKhamBenhService _service = new PhieuKhamBenhService();//

        public UC_NhapKetQua()
        {
            InitializeComponent();
        }

        private void TimKiemBtnN_Click(object sender, RoutedEventArgs e)
        {
            string maBenhNhan = TKmaBenhNhanTxtN.Text.Trim();
            if (string.IsNullOrEmpty(maBenhNhan))
            {
                MessageBox.Show("Vui lòng nhập mã bệnh nhân để tìm kiếm bệnh nhân", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                TKmaBenhNhanTxtN.Focus();
                return;
            }
            var bnN = _service.SearchBenhNhanByMaBenhNhan(maBenhNhan);
            if(bnN.Count == 0)
            {
                KetQuaBenhNhanDataGirdN.ItemsSource = null;
                MessageBox.Show("Vui lòng kiểm tra lại mã bệnh nhân hoặc trong cơ sở dữ liệu không có mã bệnh nhân này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TKmaBenhNhanTxtN.Focus();
                return;
            }
            //Đổ data lên data gird nếu tìm thấy
            KetQuaBenhNhanDataGirdN.ItemsSource = bnN;


        }

        private void NhapKetQuaBtnN_Click(object sender, RoutedEventArgs e)
        {
            if(KetQuaBenhNhanDataGirdN.SelectedItem is not PhieuKhamBenh kqKB)
            {
                MessageBox.Show("Vui lòng tìm kiếm bệnh nhân để nhập kết quả", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                TKmaBenhNhanTxtN.Focus();
                return;
            }
            //Cập nhật dữ liệu từ textbox bác sĩ, kết quả vào đối tượng
            kqKB.BacSi = BacSiTxtN.Text;
            kqKB.KetQua = KetQuaTxtN.Text;
            //Gọi _service để cập nhật vào database
            _service.UpdateKetQua(kqKB);

            MessageBox.Show("Nhập kết quả khám bệnh cho bệnh nhân thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            DeleteTxtNhapKetQua();
            TKmaBenhNhanTxtN.Text = "";
            KetQuaBenhNhanDataGirdN.ItemsSource = null;


        }

        private void LamTuoiBtnN_Click(object sender, RoutedEventArgs e)
        {
            if(MaBenhNhanTxtN.Text == "" && MaPhieuTxtN.Text == "" && NgayKhamTxtN.Text == "" && BuoiKhamTxtN.Text == "" && TrieuChungTxtN.Text == "" && TenKhoaTxtN.Text == "" && BacSiTxtN.Text == "" && KetQuaTxtN.Text == "" && TKmaBenhNhanTxtN.Text == "" && KetQuaBenhNhanDataGirdN.ItemsSource == null)
            {
                MessageBox.Show("Không có data để làm tươi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var result = MessageBox.Show("Bạn có chắc muốn làm tươi không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                DeleteTxtNhapKetQua();
                TKmaBenhNhanTxtN.Text = "";
                KetQuaBenhNhanDataGirdN.ItemsSource = null;
                return;
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            KetQuaBenhNhanDataGirdN.ItemsSource = null;
        }

        private void KetQuaBenhNhanDataGirdN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(KetQuaBenhNhanDataGirdN.SelectedItem is PhieuKhamBenh kqBNhanN)
            {
                MaPhieuTxtN.Text = kqBNhanN.MaPhieu.ToString();
                MaBenhNhanTxtN.Text = kqBNhanN.MaBenhNhan;
                NgayKhamTxtN.Text = kqBNhanN.NgayKham;
                BuoiKhamTxtN.Text = kqBNhanN.Buoi;
                TrieuChungTxtN.Text = kqBNhanN.TrieuChung;
                TenKhoaTxtN.Text = kqBNhanN.TenKhoa;
                BacSiTxtN.Text = kqBNhanN.BacSi;
                KetQuaTxtN.Text = kqBNhanN.KetQua;

            }

        }

        //Hàm delete textbox
        private void DeleteTxtNhapKetQua()
        {
            MaBenhNhanTxtN.Text = "";
            MaPhieuTxtN.Text = "";
            NgayKhamTxtN.Text = "";
            BuoiKhamTxtN.Text = "";
            TrieuChungTxtN.Text = "";
            TenKhoaTxtN.Text = "";
            BacSiTxtN.Text = "";
            KetQuaTxtN.Text = "";
        }


    }
}
