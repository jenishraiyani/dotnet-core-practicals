using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practical_18.Models;
using Practical_18.Controllers.Api;
using Practical_18.Interfaces;

namespace Practical_18.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<IActionResult> Index() { 
            List<StudentDto> studentList = new List<StudentDto>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7231/api/Student"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    studentList = JsonConvert.DeserializeObject<List<StudentDto>>(apiResponse);
                }
            }
            return View(studentList);   
        }

        public ActionResult Create()
        {
            StudentDto studentDto = new StudentDto();
            return PartialView("Create",studentDto);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _studentService.GetStudentById(id);
            StudentDto studentDto = new StudentDto();
            studentDto.StudentName = result.StudentName;
            studentDto.Phone = result.Phone;
            studentDto.Email = result.Email;
            studentDto.StudentId = result.StudentId;
            return PartialView("Edit", studentDto);
        }
    }
}
