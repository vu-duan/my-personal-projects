using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Services
{
    public class KhoaBenhService
    {
        private KhoaBenhRepository _repo1 = new KhoaBenhRepository();
        //Hàm crud++
        public List<KhoaBenh> GetAllKhoaBenh()
        {
            return _repo1.GetAll();  // Lấy data từ class repo
        }

        //Hàm Add...
        public void AddKBenh(KhoaBenh x)
        {
            _repo1.Add(x);
        }

        //Hàm Update...()
        public void UpdateKBenh(KhoaBenh x)
        {
            _repo1.Update(x);
        }
        

    }
}
