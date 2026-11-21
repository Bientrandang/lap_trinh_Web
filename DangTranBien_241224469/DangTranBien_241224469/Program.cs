using System.Text.Encodings.Web;
using System.Text.Unicode;
using DangTranBien_241224469.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình không mã hóa ký tự Unicode tiếng Việt thành HTML entities
builder.Services.AddSingleton<HtmlEncoder>(
    HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<QLTaiSanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") 
        ?? "Server=.;Database=QLTaiSan;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
