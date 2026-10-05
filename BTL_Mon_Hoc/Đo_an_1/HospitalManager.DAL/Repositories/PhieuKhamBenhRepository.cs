using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Repositories
{
    public class PhieuKhamBenhRepository
    {
        private DoAnThietKe1Context _context;

        //Các hàm Crud cơ bản: SELECT, INSERT, UPDATE, DELETE
        //Tên các hàm này: Thô + Ngắn
        
        //Hàm GetAll();
        public List<PhieuKhamBenh> GetAll()
        {
            _context = new DoAnThietKe1Context();
            return _context.PhieuKhamBenhs.ToList();
        }

        //Hàm Add();
        public void Add(PhieuKhamBenh x)
        {
            _context = new DoAnThietKe1Context();
            _context.PhieuKhamBenhs.Add(x);
            _context.SaveChanges();  //Lưu thực sự
        }

        //Hàm Update()
        public void Update(PhieuKhamBenh x)
        {
            _context = new DoAnThietKe1Context();
            _context.PhieuKhamBenhs.Update(x);
            _context.SaveChanges();
        }


    }
}
