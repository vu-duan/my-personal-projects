using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Repositories
{
    public class BenhNhanRepository
    {
        private DoAnThietKe1Context _context;

        //Chứa 4 hàm CRUD CƠ BẢN: SELECT , INSERT, DELETE, UPDATE

        //Hàm GetAll()
        public List<BenhNhan> GetAll()
        {
            _context = new DoAnThietKe1Context();
            return _context.BenhNhans.ToList();
        }

        //Hàm Add()
        public void Add(BenhNhan x)
        {   
            _context = new DoAnThietKe1Context();
            _context.BenhNhans.Add(x);    // INSERT INTO (Lưu vào ram)
            _context.SaveChanges();       // Lưu thực sự xuống table database

        }
        //hàm Update
        public void Update(BenhNhan x)
        {
            _context = new DoAnThietKe1Context();
            _context.BenhNhans.Update(x);   //Lưu vào ram
            _context.SaveChanges();      //Lưu vào database
        }

    }
}
