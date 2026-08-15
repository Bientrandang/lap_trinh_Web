using System;
using System.Collections.Generic;
using System.Text;

namespace Dtb_Lesson01
{
    internal class Student
    {
        public string mssv { get; set; }
        public string name { get; set; }
        public DateTime? Ngaysinh { get; set; }

        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string NganhHoc { get; set; }
        public double DiemTrungBinh { get; set; }
        public string TrangThaiHocTap { get; set; }
    }
}