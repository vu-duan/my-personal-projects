using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Services
{
    public class BacSiService
    {   
        private BacSiRepository _repo = new BacSiRepository();
        //hàm crud++
        //Tên hàm đặt dễ hiểu, gần hơn với người dùng
        public List<BacSi> GetAllBacSi()
        {
            return _repo.GetAll();
        }
        //Hàm Add...
        public void AddBs(BacSi x)
        {
            _repo.Add(x);
        }
        //Hàm Update...()
        public void UpdateTTBsi(BacSi x)
        {
            _repo.Update(x);
        }

        //Hàm tìm kiếm thông tin bác sĩ phục vụ user:Bác sĩ để tra cứu + chỉnh sửa thông tin
        public List<BacSi> SearchBacSiByMaBacSi(String MaBacSi)
        {
            List<BacSi> _result = _repo.GetAll();

            return _result.Where(x => x.MaBacSi == MaBacSi).ToList();
        }


    }
}
