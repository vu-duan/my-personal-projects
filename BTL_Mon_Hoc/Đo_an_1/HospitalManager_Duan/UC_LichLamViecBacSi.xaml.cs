using HospitalManager.BLL.Services;
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
    /// Interaction logic for UC_LichLamViecBacSi.xaml
    /// </summary>
    public partial class UC_LichLamViecBacSi : UserControl
    {
        private PhieuKhamBenhService _service = new PhieuKhamBenhService();

        public UC_LichLamViecBacSi()
        {
            InitializeComponent();
        }

        private void TraCuuBtnLlv_Click(object sender, RoutedEventArgs e)
        {
            string ngayLV = TKNgayKhamTxtL.Text.Trim();
            if (string.IsNullOrEmpty(ngayLV))
            {
                MessageBox.Show("Vui lòng nhập ngày làm việc để tra cứu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                TKNgayKhamTxtL.Focus();
                return;
            }
            var nlv = _service.SearchLichLamViecByNgay(ngayLV);
            if(nlv.Count == 0)
            {
                MessageBox.Show("Hôm nay không có bệnh nhân đăng ký khám bệnh", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information );
                return;
            }
            //Đổ data lên datagird nếu tìm thấy
            LichLamViecDataGirdL.ItemsSource = nlv;

        }

        private void LamTuoiBtnLlv_Click(object sender, RoutedEventArgs e)
        {
            if(TKNgayKhamTxtL.Text == "" && LichLamViecDataGirdL.ItemsSource == null)
            {
                MessageBox.Show("Không có data để làm tươi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var resul = MessageBox.Show("Bạn có muốn làm tươi không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(resul == MessageBoxResult.Yes)
            {
                TKNgayKhamTxtL.Text = "";
                LichLamViecDataGirdL.ItemsSource = null;


            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LichLamViecDataGirdL.ItemsSource = null;
        }
    }
}
