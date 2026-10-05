using HospitalManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.DAL.Repositories
{
    public class BacSiRepository
    {   
        //Video 17
        private DoAnThietKe1Context _context; //Khi nào dùng thì mới new

        //Dưới đây là các hàm Crud ứng với các lệnh của table(thêm, xóa, sửa, cập nhật)
        //Đặt tên hàm: Thô + ngắn gọn (vì gần với database)
        public List<BacSi> GetAll()
        {
            _context = new DoAnThietKe1Context();
            return _context.BacSis.ToList();  // như là câu lệnh Select * from BacSi(lấy database đưa vào ram)
        }

        //Hàm Add();
        public void Add(BacSi x)
        {
            _context = new DoAnThietKe1Context();
            _context.BacSis.Add(x);   //Lưu vào ra
            _context.SaveChanges();   // Lưu thực sự vào table database
        }
        //Hàm Update()
        public void Update(BacSi x)
        {
            _context = new DoAnThietKe1Context();
            _context.BacSis.Update(x);
            _context.SaveChanges();
        }



    }
}
