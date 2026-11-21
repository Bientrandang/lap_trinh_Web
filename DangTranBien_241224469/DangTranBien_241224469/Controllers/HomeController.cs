using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DangTranBien_241224469.Models;

namespace DangTranBien_241224469.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly QLHangHoaContext _context;

    public HomeController(ILogger<HomeController> logger, QLHangHoaContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index(int? maLoai)
    {
        var query = _context.HangHoas.Where(h => h.Gia != null && h.Gia >= 100);

        if (maLoai.HasValue && maLoai.Value > 0)
        {
            query = query.Where(h => h.MaLoai == maLoai.Value);
        }

        var list = await query.ToListAsync();
        ViewBag.SelectedMaLoai = maLoai ?? 0;
        return View(list);
    }

    // AJAX Endpoint to get HangHoa filtered by LoaiHang
    [HttpGet]
    public async Task<IActionResult> GetHangHoaByLoai(int? maLoai)
    {
        var query = _context.HangHoas.Where(h => h.Gia != null && h.Gia >= 100);

        if (maLoai.HasValue && maLoai.Value > 0)
        {
            query = query.Where(h => h.MaLoai == maLoai.Value);
        }

        var list = await query.ToListAsync();
        return PartialView("DangTranBien_MainContent", list);
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
