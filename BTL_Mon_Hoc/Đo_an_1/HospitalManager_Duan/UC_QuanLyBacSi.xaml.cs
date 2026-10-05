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
    /// Interaction logic for UC_QuanLyBacSi.xaml
    /// </summary>
    public partial class UC_QuanLyBacSi : UserControl
    {   
        private BacSiService _service = new BacSiService();
        

        public UC_QuanLyBacSi()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        //Hàm đổ vào lưới để dùng nhiều lần
        // Thêm => Đổ vào lưới, xóa => Đổ vào lưới,...
        private void FillDataGrid()
        {
            BacSiDataGridQLBS.ItemsSource = null; // Xóa data tại  trước khi load, thêm, xóa, sửa, update
            BacSiDataGridQLBS.ItemsSource = _service.GetAllBacSi();  //thực hiện đổ data vào lưới khi bấm button hoặc Load
        }

        private void BacSiDataGridQLBS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(BacSiDataGridQLBS.SelectedItem is BacSi bs)
            {
                MaKhoaTxtQLBs.Text = bs.MaKhoa;
                BacSiIdTxtQLBs.Text = bs.MaBacSi;
                TenBacSiTxtQLBs.Text = bs.TenBacSi;
                NamSinhTxtQLBs.Text = bs.NamSinh;
                PhoneTxtQLBs.Text = bs.Phone;
                ChucVuTxtQLBs.Text = bs.ChucVu;
                GioiTinhTxtQLBs.Text = bs.GioiTinh;

            }
        }
    }
}
