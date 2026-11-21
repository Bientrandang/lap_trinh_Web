using System.Diagnostics;
using DangTranBien_241224469.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DangTranBien_241224469.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly QLTaiSanContext _context;

    public HomeController(ILogger<HomeController> logger, QLTaiSanContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Câu 3: Load dữ liệu từ bảng TaiSan để hiển thị danh sách các TaiSan có NguyenGia >= 20, tài sản NULL không hiển thị
    public async Task<IActionResult> Index()
    {
        var danhSachTaiSan = await _context.TaiSans
            .Include(t => t.MaLoaiNavigation)
            .Where(t => t.NguyenGia != null && t.NguyenGia >= 20)
            .OrderBy(t => t.MaTs)
            .ToListAsync();

        ViewBag.SectionTitle = "DangTranBien";
        return View(danhSachTaiSan);
    }

    // Câu 4: AJAX lọc danh sách tài sản theo loại
    [HttpGet]
    public async Task<IActionResult> FilterByLoai(int maLoai)
    {
        List<TaiSan> list;
        if (maLoai <= 0)
        {
            // Trở về trang chủ / Trang của sinh viên: NguyenGia >= 20 và không null
            list = await _context.TaiSans
                .Include(t => t.MaLoaiNavigation)
                .Where(t => t.NguyenGia != null && t.NguyenGia >= 20)
                .OrderBy(t => t.MaTs)
                .ToListAsync();
        }
        else
        {
            // Lọc theo loại tài sản
            list = await _context.TaiSans
                .Include(t => t.MaLoaiNavigation)
                .Where(t => t.MaLoai == maLoai && t.NguyenGia != null)
                .OrderBy(t => t.MaTs)
                .ToListAsync();
        }

        return PartialView("_AssetGridPartial", list);
    }

    public IActionResult Create()
    {
        return RedirectToAction("Create", "TaiSan");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
