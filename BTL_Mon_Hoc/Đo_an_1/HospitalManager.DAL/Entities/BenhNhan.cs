using System;
using System.Collections.Generic;

namespace HospitalManager.DAL.Entities;

public partial class BenhNhan
{
    public string MaBenhNhan { get; set; } = null!;

    //public string MaBenhNhan1 { get; set; } = null!;

    public string TenBenhNhan { get; set; } = null!;

    public string NamSinh { get; set; } = null!;

    public string GioiTinh { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string? Phone { get; set; }
}
