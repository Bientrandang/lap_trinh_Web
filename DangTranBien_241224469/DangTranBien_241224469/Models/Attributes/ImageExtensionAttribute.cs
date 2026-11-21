using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace DangTranBien_241224469.Models.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class ImageExtensionAttribute : ValidationAttribute
{
    private readonly string[] _allowedExtensions;

    public ImageExtensionAttribute(string[] allowedExtensions)
    {
        _allowedExtensions = allowedExtensions;
        ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .png | .gif | .tiff";
    }

    public ImageExtensionAttribute()
    {
        _allowedExtensions = new[] { ".jpg", ".png", ".gif", ".tiff" };
        ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .png | .gif | .tiff";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return new ValidationResult("Tên file ảnh không được để trống");
        }

        string fileName = value.ToString()!.Trim();
        string ext = Path.GetExtension(fileName);

        if (string.IsNullOrEmpty(ext))
        {
            return new ValidationResult("Tên file ảnh phải có phần mở rộng: .jpg | .png | .gif | .tiff");
        }

        if (_allowedExtensions.Any(allowed => string.Equals(allowed, ext, StringComparison.OrdinalIgnoreCase)))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Tên file ảnh phải có đuôi: .jpg | .png | .gif | .tiff");
    }
}
