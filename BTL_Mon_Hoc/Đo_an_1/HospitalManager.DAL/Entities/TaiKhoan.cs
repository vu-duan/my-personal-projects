using System;
using System.Collections.Generic;

namespace HospitalManager.DAL.Entities;

public partial class TaiKhoan
{
    public string TaiKhoanId { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public int? Role { get; set; }

    public int TrangThai { get; set; }
}
