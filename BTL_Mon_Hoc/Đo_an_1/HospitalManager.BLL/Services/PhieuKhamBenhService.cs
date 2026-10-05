using HospitalManager.DAL.Entities;
using HospitalManager.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.BLL.Services
{
    public class PhieuKhamBenhService
    {
        private PhieuKhamBenhRepository _repo = new PhieuKhamBenhRepository();
        //hàm CRUD++

        //Hàm GetAll..()

        //Hàm ADD
        public void AddPhieuKham(PhieuKhamBenh x)
        {
            _repo.Add(x);
        }

        //Hàm tìm kiếm theo MaBenhNhan  (Bài 18)
        //Dành cho User bệnh nhân xem kết quả khám bệnh, User bác sĩ tìm kiếm bệnh nhân để nhập kết quả
        public List<PhieuKhamBenh> SearchBenhNhanByMaBenhNhan(string MaBenhNhan)
        {
            List<PhieuKhamBenh> _result = _repo.GetAll();
            
             return _result = _result.Where(x => x.MaBenhNhan == MaBenhNhan).ToList();
        }

        //Hàm tìm kiếm ngày làm việc 
        public List<PhieuKhamBenh> SearchLichLamViecByNgay(string nKham)
        {
            List<PhieuKhamBenh> _result = _repo.GetAll();

            return _result = _result.Where(x => x.NgayKham == nKham).ToList();
        }


        //Hàm Update...()  dành cho bác sĩ nhập kết quả khám bệnh
        public void UpdateKetQua(PhieuKhamBenh x)
        {
            _repo.Update(x);
        }
       
        

    }
}
