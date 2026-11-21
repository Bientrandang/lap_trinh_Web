using System;
using System.ComponentModel.DataAnnotations;

namespace DangTranBien_241224469.Models.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class GiaRangeAttribute : ValidationAttribute
{
    public double Minimum { get; set; }
    public double Maximum { get; set; }

    public GiaRangeAttribute(double minimum = 100, double maximum = 5000)
    {
        Minimum = minimum;
        Maximum = maximum;
        ErrorMessage = "Giá phải là số và nằm trong giới hạn 100 đến 5000";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Giá không được để trống");
        }

        if (decimal.TryParse(value.ToString(), out decimal gia))
        {
            if (gia >= (decimal)Minimum && gia <= (decimal)Maximum)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage ?? $"Giá phải là số và nằm trong giới hạn {Minimum} đến {Maximum}");
        }

        return new ValidationResult("Giá phải là số hợp lệ");
    }
}
