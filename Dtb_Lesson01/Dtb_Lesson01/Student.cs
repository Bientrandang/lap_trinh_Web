using System;

namespace Dtb_Lesson01
{

    internal class Student
    {
        // Properties
        public string mssv { get; set; }
        public string name { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string NganhHoc { get; set; }
        public double DiemTrungBinh { get; set; }
        public string TrangThaiHocTap { get; set; }

        // Constructor mặc định
        public Student()
        {
        }

        // Constructor đầy đủ thông tin
        public Student(
            string mssv,
            string name,
            DateTime? ngaysinh,
            string gioiTinh,
            string email,
            string soDienThoai,
            string nganhHoc,
            double diemTrungBinh,
            string trangThaiHocTap)
        {
            this.mssv = mssv;
            this.name = name;
            this.Ngaysinh = ngaysinh;
            this.GioiTinh = gioiTinh;
            this.Email = email;
            this.SoDienThoai = soDienThoai;
            this.NganhHoc = nganhHoc;
            this.DiemTrungBinh = diemTrungBinh;
            this.TrangThaiHocTap = trangThaiHocTap;
        }
    }
}