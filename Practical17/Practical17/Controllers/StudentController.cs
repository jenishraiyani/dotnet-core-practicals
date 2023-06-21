using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practical17.Interfaces;
using Practical17.Models;

namespace Practical17.Controllers
{

  
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult Index()
        {
            var students = _studentService.GetAllStudents().ToList();
            return View(students);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Students student)
        {
            if (ModelState.IsValid)
            {
                _studentService.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult Details(int id)
        {
            var students = _studentService.GetStudentById(id);
            if (students == null)
            {
                ModelState.AddModelError("UserNotFound", "User not found.");
            }
            return View(students);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var students = _studentService.GetStudentById(id);
            if (students == null)
            {
                ModelState.AddModelError("UserNotFound", "User not found.");
            }
            return View(students);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, Students student)
        {
            if (id != student.StudentId)
            {
                ModelState.AddModelError("UserNotFound", "User not found.");
            }

            if (ModelState.IsValid)
            {
                _studentService.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            int count = _studentService.DeleteStudent(id);
            if (count > 0)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}
