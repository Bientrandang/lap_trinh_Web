using DangTranBien_241224469.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DangTranBien_241224469.Controllers;

public class TaiSanController : Controller
{
    private readonly QLTaiSanContext _context;

    public TaiSanController(QLTaiSanContext context)
    {
        _context = context;
    }

    // Câu 5.1: Hiển thị form Thêm Tài sản mới
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.MaLoai = new SelectList(await _context.LoaiTaiSans.OrderBy(l => l.MaLoai).ToListAsync(), "MaLoai", "TenLoai");
        return View();
    }

    // Câu 5.1 & 5.2: Xử lý Thêm Tài sản mới có kiểm tra validate DataAnnotations
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MaTs,MaLoai,TenTs,NguyenGia,Anh")] TaiSan taiSan)
    {
        if (ModelState.IsValid)
        {
            _context.TaiSans.Add(taiSan);
            await _context.SaveChangesAsync();
            // Sau khi thêm thành công, chuyển về trang chủ và tài sản mới xuất hiện trong danh sách tương ứng
            return RedirectToAction("Index", "Home");
        }

        ViewBag.MaLoai = new SelectList(await _context.LoaiTaiSans.OrderBy(l => l.MaLoai).ToListAsync(), "MaLoai", "TenLoai", taiSan.MaLoai);
        return View(taiSan);
    }
}
