using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DangTranBien_241224469.Models;

namespace DangTranBien_241224469.Components
{
    public class MenuTheLoaiViewComponent : ViewComponent
    {
        private readonly QlnhaSachContext _db;

        public MenuTheLoaiViewComponent(QlnhaSachContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var theLoais = await _db.TheLoais.OrderBy(t => t.TenTl).ToListAsync();
            return View(theLoais);
        }
    }
}
