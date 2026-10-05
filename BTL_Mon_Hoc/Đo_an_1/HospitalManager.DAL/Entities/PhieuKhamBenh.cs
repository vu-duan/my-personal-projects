using System;
using System.Collections.Generic;

namespace HospitalManager.DAL.Entities;

public partial class PhieuKhamBenh
{
    public int MaPhieu { get; set; }

    public string? MaBenhNhan { get; set; }

    public string? BacSi { get; set; }

    public string NgayKham { get; set; } = null!;

    public string Buoi { get; set; } = null!;

    public string TrieuChung { get; set; } = null!;

    public string? KetQua { get; set; }

    //
    public string TenKhoa { get; set; } = null!;    

    public virtual BenhNhan? MaBenhNhanNavigation { get; set; }
}
