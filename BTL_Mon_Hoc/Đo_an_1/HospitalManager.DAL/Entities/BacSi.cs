using System;
using System.Collections.Generic;

namespace HospitalManager.DAL.Entities;

public partial class BacSi
{
    public string? MaKhoa { get; set; }

    public string MaBacSi { get; set; } = null!;

    public string TenBacSi { get; set; } = null!;

    public string NamSinh { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string GioiTinh { get; set; } = null!;

    public string ChucVu { get; set; } = null!;

    public virtual KhoaBenh? MaKhoaNavigation { get; set; }
}
