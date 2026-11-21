using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DangTranBien_241224469.Models;

namespace DangTranBien_241224469.Controllers;

public class HangHoaController : Controller
{
    private readonly QLHangHoaContext _context;

    public HangHoaController(QLHangHoaContext context)
    {
        _context = context;
    }

    // GET: HangHoa
    public async Task<IActionResult> Index()
    {
        var hangHoas = await _context.HangHoas.Include(h => h.MaLoaiNavigation).ToListAsync();
        return View(hangHoas);
    }

    // GET: HangHoa/Create
    public async Task<IActionResult> Create()
    {
        ViewBag.MaLoai = new SelectList(await _context.LoaiHangs.ToListAsync(), "MaLoai", "TenLoai");
        return View();
    }

    // POST: HangHoa/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MaLoai,TenHang,Gia,Anh")] HangHoa hangHoa)
    {
        if (ModelState.IsValid)
        {
            _context.Add(hangHoa);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        ViewBag.MaLoai = new SelectList(await _context.LoaiHangs.ToListAsync(), "MaLoai", "TenLoai", hangHoa.MaLoai);
        return View(hangHoa);
    }
}
