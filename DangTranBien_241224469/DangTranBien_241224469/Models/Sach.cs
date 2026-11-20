using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DangTranBien_241224469.Models;

public partial class Sach
{
    [Display(Name = "Mã sách")]
    public int MaSach { get; set; }

    [Display(Name = "Thể loại")]
    [Required(ErrorMessage = "Vui lòng chọn thể loại")]
    public int MaTl { get; set; }

    [Display(Name = "Tên sách")]
    [Required(ErrorMessage = "TenSach không được để trống")]
    public string TenSach { get; set; } = null!;

    [Display(Name = "Giá")]
    [Required(ErrorMessage = "Giá không được để trống")]
    [Range(50, 1000, ErrorMessage = "Gia phải là số và nằm trong giới hạn từ 50 đến 1000")]
    public decimal? Gia { get; set; }

    [Display(Name = "Ảnh")]
    [Required(ErrorMessage = "Ảnh không được để trống")]
    [RegularExpression(@"^.*\.(jpg|jpeg|png|webp)$", ErrorMessage = "tên file ảnh (Anh) phải có đuôi: .jpg | .jpeg | .png | .webp")]
    public string? Anh { get; set; }

    public virtual TheLoai? MaTlNavigation { get; set; }
}
