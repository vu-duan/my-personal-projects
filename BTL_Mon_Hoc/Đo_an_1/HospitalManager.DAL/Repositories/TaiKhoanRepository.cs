using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Repositories
{
    public class TaiKhoanRepository
    {
        //video 17
        

        private DoAnThietKe1Context _context;  

        //Trong đây chứa các hàm(CRUD 4 LỆNH SQL CƠ BẢN -->SELECT , INSERT, DELETE, UPDATE)
        // Tên hàm đặt: Thô + ngắn (vì nó gần với database)
        public TaiKhoan? GetOne(string email, string password)
        {
            _context = new DoAnThietKe1Context();
            return _context.TaiKhoans.FirstOrDefault(x => x.EmailAddress.ToLower() == email.ToLower() && x.MatKhau == password);   //Trả về 1 dòng OR trả về null (Sai 1 or sai cả 2)
        }

        public List<TaiKhoan> GetAll()
        {
            _context = new DoAnThietKe1Context();
            return _context.TaiKhoans.ToList();      // SELECT * FROM TaiKhoan
        }

        //Hàm Add()
        public void Add(TaiKhoan x)
        {
            _context = new DoAnThietKe1Context();
            _context.TaiKhoans.Add(x); // Lưu vào ram
            _context.SaveChanges(); //Lưu thực sự xuống Table của database

        }//TODO: khi trùng key thì sao?

        //Hàm Update
        public void Update(TaiKhoan x)
        {
            _context = new DoAnThietKe1Context();
            _context.TaiKhoans.Update(x);  //Ram
            _context.SaveChanges();        //Table
        }

        //Hàm Delete
        public void Delete(TaiKhoan x)
        {
            _context = new DoAnThietKe1Context();
            _context.TaiKhoans.Remove(x);      //Ram
            _context.SaveChanges();            //Table
        }

    }
}
