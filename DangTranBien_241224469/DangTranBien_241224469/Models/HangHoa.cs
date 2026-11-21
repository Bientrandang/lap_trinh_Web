using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DangTranBien_241224469.Models.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace DangTranBien_241224469.Models;

[Table("HangHoa")]
public partial class HangHoa
{
    [Key]
    [Display(Name = "Mã hàng")]
    public int MaHang { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn loại hàng")]
    [Display(Name = "Loại hàng")]
    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Tên hàng không được để trống")]
    [StringLength(50, ErrorMessage = "Tên hàng tối đa 50 ký tự")]
    [Display(Name = "Tên hàng")]
    public string TenHang { get; set; } = null!;

    [Required(ErrorMessage = "Giá không được để trống")]
    [Range(100, 5000, ErrorMessage = "Giá phải là số và nằm trong giới hạn 100 đến 5000")]
    [GiaRange(100, 5000, ErrorMessage = "Giá phải là số và nằm trong giới hạn 100 đến 5000")]
    [Column(TypeName = "numeric(18, 0)")]
    [Display(Name = "Giá")]
    public decimal? Gia { get; set; }

    [Required(ErrorMessage = "Tên file ảnh không được để trống")]
    [StringLength(100, ErrorMessage = "Tên file ảnh tối đa 100 ký tự")]
    [RegularExpression(@"^.+\.(jpg|png|gif|tiff|JPG|PNG|GIF|TIFF)$", ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .png | .gif | .tiff")]
    [ImageExtension(ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .png | .gif | .tiff")]
    [Display(Name = "Ảnh")]
    public string? Anh { get; set; }

    [ForeignKey("MaLoai")]
    [InverseProperty("HangHoas")]
    [ValidateNever]
    public virtual LoaiHang? MaLoaiNavigation { get; set; }
}
