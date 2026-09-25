using DTBLesson06Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace DTBLesson06Models.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Dtb_User> Users = new List<Dtb_User>
        {
            new Dtb_User
            {
                DtbId = 1,
                DtbName = "Nguyễn Văn A",
                DtbAddress = "Hà Nội",
                DtbEmail = "nguyenvana@gmail.com"
            },
            new Dtb_User
            {
                DtbId = 2,
                DtbName = "Trần Thị B",
                DtbAddress = "Hải Phòng",
                DtbEmail = "tranthib@gmail.com"
            },
            new Dtb_User
            {
                DtbId = 3,
                DtbName = "Lê Văn C",
                DtbAddress = "Quảng Ninh",
                DtbEmail = "levanc@gmail.com"
            }
        };

        public IActionResult Index()
        {
            return View("Dtb_Index", Users);
        }

        public IActionResult Create()
        {
            return View("Dtb_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Dtb_User user)
        {
            if (!ModelState.IsValid)
                return View("Dtb_Create", user);

            user.DtbId = Users.Count == 0 ? 1 : Users.Max(x => x.DtbId) + 1;
            Users.Add(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(long id)
        {
            var user = Users.FirstOrDefault(x => x.DtbId == id);
            if (user == null)
                return NotFound();

            return View("Dtb_Details", user);
        }

        public IActionResult Edit(long id)
        {
            var user = Users.FirstOrDefault(x => x.DtbId == id);
            if (user == null)
                return NotFound();

            return View("Dtb_Edit", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Dtb_User user)
        {
            if (!ModelState.IsValid)
                return View("Dtb_Edit", user);

            var oldUser = Users.FirstOrDefault(x => x.DtbId == user.DtbId);
            if (oldUser == null)
                return NotFound();

            oldUser.DtbName = user.DtbName;
            oldUser.DtbAddress = user.DtbAddress;
            oldUser.DtbEmail = user.DtbEmail;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(long id)
        {
            var user = Users.FirstOrDefault(x => x.DtbId == id);
            if (user == null)
                return NotFound();

            return View("Dtb_Delete", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var user = Users.FirstOrDefault(x => x.DtbId == id);
            if (user != null)
                Users.Remove(user);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View("Dtb_Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Dtb_Login login)
        {
            if (login.DtbUserName == "Peter" && login.DtbPassword == "pass@123")
            {
                return Content("Welcome " + login.DtbUserName);
            }

            ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return View("Dtb_Login", login);
        }
    }
}
