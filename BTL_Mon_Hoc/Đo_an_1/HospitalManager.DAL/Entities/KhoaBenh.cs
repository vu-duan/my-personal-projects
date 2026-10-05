using System;
using System.Collections.Generic;

namespace HospitalManager.DAL.Entities;

public partial class KhoaBenh
{
    public string MaKhoa { get; set; } = null!;

    public string TenKhoa { get; set; } = null!;

    public string DiaChiKhoa { get; set; } = null!;

    public virtual ICollection<BacSi> BacSis { get; set; } = new List<BacSi>();
}
