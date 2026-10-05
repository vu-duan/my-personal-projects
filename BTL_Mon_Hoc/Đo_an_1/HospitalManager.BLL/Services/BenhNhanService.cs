using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Services
{   
    
    public class BenhNhanService
    {
        private BenhNhanRepository _repo = new BenhNhanRepository();

        //Hàm GetAll...


        //Hàm Add..
        //Từ Gui(UI) phải gửi dữ liệu của x cho hàm AddBenhNhan
        public void AddBenhNhan(BenhNhan x)
        {
            _repo.Add(x);
        }

        //Hàm tìm kiếm thông tin bệnh nhân áp dụng cho user:Bệnh nhân, bác sĩ
        public List<BenhNhan> RearchTTBenhNhanByCccd(string Cccd)
        {
            List<BenhNhan> _result = _repo.GetAll();

            return _result = _result.Where(x => x.MaBenhNhan == Cccd).ToList();
        }

        //Hàm Update..()
        public void UpdateTTBenhNhan(BenhNhan x)
        {
            _repo.Update(x);
        }

        /*
        //Hàm tìm kiếm Thông tin bệnh nhân theo table:BenhNhan bằng mã bệnh nhân
        public List<BenhNhan> BacSiSearchBenhNhanByMaBenhNhan(string MaBN)
        {
            List<BenhNhan> _result = _repo.GetAll();

            return _result = _result.Where(x => x.MaBenhNhan == MaBN).ToList();

        }
        */

    }
}
