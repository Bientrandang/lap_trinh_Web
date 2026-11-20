using DangTranBien_241224469.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DangTranBien_241224469.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlnhaSachContext _db;

        public HomeController(QlnhaSachContext db)
        {
            _db = db;
        }

        // Câu 3: Hiển thị sách có Giá >= 100, bỏ qua sách có giá NULL, tiêu đề là tên sinh viên
        public async Task<IActionResult> Index()
        {
            var books = await _db.Saches
                .Where(s => s.Gia.HasValue && s.Gia.Value >= 100)
                .ToListAsync();

            ViewBag.TitleCategory = "ĐẶNG TRẦN BIÊN";
            return View(books);
        }

        // Câu 4: Lọc sách theo thể loại bằng AJAX
        [HttpGet]
        public async Task<IActionResult> GetSachByTheLoai(int? maTL)
        {
            List<Sach> books;
            if (maTL == null || maTL == 0)
            {
                // Nhấn vào họ tên sinh viên (Trang chủ) -> hiện sách có Giá >= 100
                books = await _db.Saches
                    .Where(s => s.Gia.HasValue && s.Gia.Value >= 100)
                    .ToListAsync();
            }
            else
            {
                // Nhấn vào thể loại cụ thể -> lọc theo MaTL (loại bỏ sách có giá NULL)
                books = await _db.Saches
                    .Where(s => s.MaTl == maTL && s.Gia.HasValue)
                    .ToListAsync();
            }

            return PartialView("_DangTranBien_MainConttent", books);
        }

        // Câu 5: Thêm sách mới (GET)
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.MaTl = new SelectList(await _db.TheLoais.OrderBy(t => t.TenTl).ToListAsync(), "MaTl", "TenTl");
            ViewBag.TitleCategory = "ĐẶNG TRẦN BIÊN - THÊM SÁCH MỚI";
            return View();
        }

        // Câu 5: Thêm sách mới (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTl,TenSach,Gia,Anh")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                _db.Add(sach);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MaTl = new SelectList(await _db.TheLoais.OrderBy(t => t.TenTl).ToListAsync(), "MaTl", "TenTl", sach.MaTl);
            ViewBag.TitleCategory = "ĐẶNG TRẦN BIÊN - THÊM SÁCH MỚI";
            return View(sach);
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
}
