using DTBLesson06Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace DTBLesson06Models.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<DtbMember> Members = new List<DtbMember>
        {
            new DtbMember
            {
                DtbMemberId = Guid.NewGuid(),
                DtbMemberUserName = "abc",
                DtbMemberPassword = "123456a@",
                DtbMemberEmail = "abc@gmail.com",
                DtbMemberFullName = "Abc"
            },
            new DtbMember
            {
                DtbMemberId = Guid.NewGuid(),
                DtbMemberUserName = "tranthib",
                DtbMemberPassword = "123456",
                DtbMemberEmail = "tranthib@gmail.com",
                DtbMemberFullName = "Trần Thị B"
            },
            new DtbMember
            {
                DtbMemberId = Guid.NewGuid(),
                DtbMemberUserName = "levanc",
                DtbMemberPassword = "123456",
                DtbMemberEmail = "levanc@gmail.com",
                DtbMemberFullName = "Lê Văn C"
            },
            new DtbMember
            {
                DtbMemberId = Guid.NewGuid(),
                DtbMemberUserName = "phamthid",
                DtbMemberPassword = "123456",
                DtbMemberEmail = "phamthid@gmail.com",
                DtbMemberFullName = "Phạm Thị D"
            },
            new DtbMember
            {
                DtbMemberId = Guid.NewGuid(),
                DtbMemberUserName = "hoangvane",
                DtbMemberPassword = "123456",
                DtbMemberEmail = "hoangvane@gmail.com",
                DtbMemberFullName = "Hoàng Văn E"
            }
        };

        public static List<DtbMember> Members1 => Members;

        public IActionResult Index()
        {
            return View(Members1);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DtbMember member)
        {
            member.DtbMemberId = Guid.NewGuid();
            Members1.Add(member);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid id)
        {
            var member = Members1.FirstOrDefault(x => x.DtbMemberId == id);
            if (member == null) return NotFound();
            return View(member);
        }

        public IActionResult Edit(Guid id)
        {
            var member = Members1.FirstOrDefault(x => x.DtbMemberId == id);
            if (member == null) return NotFound();
            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(DtbMember member)
        {
            var oldMember = Members1.FirstOrDefault(x => x.DtbMemberId == member.DtbMemberId);
            if (oldMember == null) return NotFound();

            oldMember.DtbMemberUserName = member.DtbMemberUserName;
            oldMember.DtbMemberPassword = member.DtbMemberPassword;
            oldMember.DtbMemberEmail = member.DtbMemberEmail;
            oldMember.DtbMemberFullName = member.DtbMemberFullName;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            var member = Members1.FirstOrDefault(x => x.DtbMemberId == id);
            if (member == null) return NotFound();
            return View(member);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var member = Members1.FirstOrDefault(x => x.DtbMemberId == id);
            if (member != null)
                Members1.Remove(member);

            return RedirectToAction(nameof(Index));
        }
    }
}