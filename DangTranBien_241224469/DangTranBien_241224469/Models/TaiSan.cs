using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DangTranBien_241224469.Models;

public partial class TaiSan
{
    public int MaTs { get; set; }

    [Display(Name = "Loại tài sản")]
    [Required(ErrorMessage = "Vui lòng chọn loại tài sản")]
    public int MaLoai { get; set; }

    [Display(Name = "Tên tài sản")]
    [Required(ErrorMessage = "Tên tài sản không được để trống")]
    [StringLength(100, ErrorMessage = "Tên tài sản không được vượt quá 100 ký tự")]
    public string TenTs { get; set; } = null!;

    [Display(Name = "Nguyên giá (triệu)")]
    [Required(ErrorMessage = "Nguyên giá không được để trống")]
    [Range(1, 2000, ErrorMessage = "Nguyên giá phải là số từ 1 đến 2000")]
    public decimal? NguyenGia { get; set; }

    [Display(Name = "Tên file ảnh")]
    [Required(ErrorMessage = "Tên file ảnh không được để trống")]
    [RegularExpression(@"^.+\.(jpg|jpeg|png|webp|JPG|JPEG|PNG|WEBP)$", ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
    public string? Anh { get; set; }

    [ValidateNever]
    public virtual LoaiTaiSan? MaLoaiNavigation { get; set; }
}
