using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new List<Student>()
        {
            new Student() { Id = 101, Name = "Hải Nam", Branch = Branch.IT,
                Gender = Gender.Male, IsRegular = true,
                Address = "A1-2018", Email = "nam@g.com" },
            new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
                Gender = Gender.Female, IsRegular = true,
                Address = "A1-2019", Email = "tu@g.com" },
            new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
                Gender = Gender.Male, IsRegular = false,
                Address = "A1-2020", Email = "phong@g.com" },
            new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
                Gender = Gender.Female, IsRegular = false,
                Address = "A1-2021", Email = "mai@g.com" }
        };

        public StudentController()
        {
        }

        [Route("Admin/Student/List", Name = "student_list")]
        [Route("Student/Index")]
        [Route("Student")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        [Route("Admin/Student/Add", Name = "student_add")]
        [Route("Student/Create")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "IT" },
                new SelectListItem { Text = "BE", Value = "BE" },
                new SelectListItem { Text = "CE", Value = "CE" },
                new SelectListItem { Text = "EE", Value = "EE" }
            };
            return View();
        }

        [HttpPost]
        [Route("Admin/Student/Add")]
        [Route("Student/Create")]
        public async Task<IActionResult> Create(Student s, IFormFile? avatarFile)
        {
            if (avatarFile != null && avatarFile.Length > 0)
            {
                var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "avatars");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(avatarFile.FileName)}";
                var filePath = Path.Combine(uploadDir, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await avatarFile.CopyToAsync(stream);
                }
                s.AvatarUrl = $"/images/avatars/{fileName}";
            }

            s.Id = (listStudents.Count > 0 ? listStudents.Last().Id : 100) + 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
    }
}
