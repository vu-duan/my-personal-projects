using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Repositories
{
    public class KhoaBenhRepository
    {

        private DoAnThietKe1Context _context;

        //Các hàm CRUD CƠ BẢN

        //hÀM GetAdd()
        public List<KhoaBenh> GetAll()
        {
            _context = new DoAnThietKe1Context();
            return _context.KhoaBenhs.ToList();   // Select * from KhoaBenh
        }

        //Hàm Add()
        public void Add(KhoaBenh x)
        {
            _context = new DoAnThietKe1Context();
            _context.KhoaBenhs.Add(x);   //Lưu vào ram
            _context.SaveChanges();     // Lưu thực sự xuống table của database
        }
        //Hàm Update
        public void Update(KhoaBenh x)
        {
            _context = new DoAnThietKe1Context();
            _context.KhoaBenhs.Update(x);  //Lưu vào ram
            _context.SaveChanges();        // Lưu thực sự xuống table của database
        }

        
        

    }
}
