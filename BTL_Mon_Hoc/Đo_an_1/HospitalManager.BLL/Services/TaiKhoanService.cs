using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Services
{
    public class TaiKhoanService
    {   
        //Tầng Service thì gọi Repository
        // nhiệm vụ: Để lấy dữ liệu ở tầng Repo về Tầng Servi
        private TaiKhoanRepository _repo = new TaiKhoanRepository();

        //Viết hàm trong Clas TaiKhoanService
        // Các hàm CRUD++
        //Tên hàm: Đặt phải dễ hiểu và Gần với người dùng
        public TaiKhoan? Authenticate(string email, string password)
        {
            return _repo.GetOne(email, password);
        }

        public List<TaiKhoan> GetAllTaiKhoans()
        {
            return _repo.GetAll();  
        }

        //Hàm Add..()
        public void AddTK(TaiKhoan x)
        {
            _repo.Add(x);
        }

        //Hàm Update...()
        public void UpdateTK(TaiKhoan x)
        {
            _repo.Update(x);
        }
        //Hàm Delete..()
        public void DeleteTK(TaiKhoan x)
        {
            _repo.Delete(x);
        }


    }
}
