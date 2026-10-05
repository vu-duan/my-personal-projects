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
    /// Interaction logic for UC_LichSuKhamBenh.xaml
    /// </summary>
    public partial class UC_LichSuKhamBenh : UserControl
    {   
        private PhieuKhamBenhService _service = new PhieuKhamBenhService();

        public UC_LichSuKhamBenh()
        {
            InitializeComponent();
        }

        private void BtnTkiemLSKBenh_Click(object sender, RoutedEventArgs e)
        {
            string maBN = MaBNhanLSKBenhTK.Text.Trim();
            if (string.IsNullOrEmpty(maBN) )
            {
                MessageBox.Show("Vui lòng nhập căn cước công dân để tìm kiếm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var bnx = _service.SearchBenhNhanByMaBenhNhan(maBN);
            if(bnx.Count == 0)
            {
                LichSuKhamBenhDataGirdBN.ItemsSource = null;
                MessageBox.Show("Vui lòng kiểm tra lại căn cưới công dân của bạn!", "Thông báo");
                return;
            }
            //Fill data lên data gird nếu tìm thấy
            LichSuKhamBenhDataGirdBN.ItemsSource = bnx;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LichSuKhamBenhDataGirdBN.ItemsSource = null; //5:45 ngày 2/6
        }

        private void BtnLamTuoiLSKBenh_Click(object sender, RoutedEventArgs e)
        {   
            if(MaBNhanLSKBenhTK.Text == "" && LichSuKhamBenhDataGirdBN.ItemsSource == null)
            {
                MessageBox.Show("Không có data để làm tươi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var resultLamTuoiLSKbenh = MessageBox.Show("Bạn có chắc muốn làm tươi không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(resultLamTuoiLSKbenh == MessageBoxResult.Yes)
            {
                MaBNhanLSKBenhTK.Text = "";
                LichSuKhamBenhDataGirdBN.ItemsSource = null;
                MaPhieuTxtLK.Text = "";
                MaBenhNhanTxtLK.Text = "";
                NgayKhamTxtLK.Text = "";
                BuoiKhamTxtLK.Text = "";
                TenKhoaTxtLK.Text = "";
                TrieuChungTxtLK.Text = "";
                BacSiTxtLK.Text = "";
                KetQuaTxtLK.Text = "";
                return;
            }
        }

        private void LichSuKhamBenhDataGirdBN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(LichSuKhamBenhDataGirdBN.SelectedItem is PhieuKhamBenh bnhan)
            {
                MaPhieuTxtLK.Text = bnhan.MaPhieu.ToString();
                MaBenhNhanTxtLK.Text = bnhan.MaBenhNhan;
                NgayKhamTxtLK.Text = bnhan.NgayKham;
                BuoiKhamTxtLK.Text = bnhan.Buoi;
                TenKhoaTxtLK.Text = bnhan.TenKhoa;
                TrieuChungTxtLK.Text = bnhan.TrieuChung;
                BacSiTxtLK.Text = bnhan.BacSi;
                KetQuaTxtLK.Text = bnhan.KetQua;
            }
        }
    }

}
