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
    /// Interaction logic for UC_QuanLyBenhNhan.xaml
    /// </summary>
    public partial class UC_QuanLyBenhNhan : UserControl
    {   
        private BenhNhanService _service = new BenhNhanService();  //3/6/2026

        public UC_QuanLyBenhNhan()
        {
            InitializeComponent();
        }

        private void TraCuuBtnQ_Click(object sender, RoutedEventArgs e)
        {
            string maBNhanQ = CccdBNhanTxtQ.Text.Trim();
            if (string.IsNullOrEmpty(maBNhanQ))
            {
                MessageBox.Show("Vui lòng nhập mã bệnh nhân để tra cứu thông tin bệnh nhân!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                CccdBNhanTxtQ.Focus();
                return;
            }
            var bnQ = _service.RearchTTBenhNhanByCccd(maBNhanQ);
            if(bnQ.Count == 0)
            {
                QuanLyBenhNhanDataGridQ.ItemsSource = null;
                MessageBox.Show("Vui lòng kiểm tra lại mã bệnh nhân hoặc chưa có thông tin bệnh nhân trong cơ sở dữ liệu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                CccdBNhanTxtQ.Focus();
                return;
            }
            //Đổ data lên datagird nếu tìm thấy thông tin bệnh nhân
            QuanLyBenhNhanDataGridQ.ItemsSource = bnQ;



        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            QuanLyBenhNhanDataGridQ.ItemsSource = null;
        }

        private void QuanLyBenhNhanDataGridQ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(QuanLyBenhNhanDataGridQ.SelectedItem is BenhNhan bNhanQ)
            {
                MaBenhNhanTxtQ.Text = bNhanQ.MaBenhNhan;
                TenBenhNhanTxtQ.Text = bNhanQ.TenBenhNhan;
                NamSinhTxtQ.Text = bNhanQ.NamSinh;
                GioiTinhTxtQ.Text = bNhanQ.GioiTinh;
                DiaChiTxtQ.Text = bNhanQ.DiaChi;
                PhoneTxtQ.Text = bNhanQ.Phone;
            }
        }

        private void LamTuoiBtnQ_Click(object sender, RoutedEventArgs e)
        {
            if(MaBenhNhanTxtQ.Text == "" && TenBenhNhanTxtQ.Text == "" && NamSinhTxtQ.Text == "" && GioiTinhTxtQ.Text == "" && DiaChiTxtQ.Text == "" &&  PhoneTxtQ.Text == "" && CccdBNhanTxtQ.Text == "" && QuanLyBenhNhanDataGridQ.ItemsSource == null)
            {
                MessageBox.Show("Không có data để làm tươi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var result = MessageBox.Show("Bạn có muốn xóa toàn bộ data ở các ô nhập hoặc trên table không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                MaBenhNhanTxtQ.Text = "";
                TenBenhNhanTxtQ.Text = "";
                NamSinhTxtQ.Text = "";
                GioiTinhTxtQ.Text = "";
                DiaChiTxtQ.Text = "";
                PhoneTxtQ.Text = "";
                CccdBNhanTxtQ.Text = "";
                QuanLyBenhNhanDataGridQ.ItemsSource = null;
            }
        }

    }
}
