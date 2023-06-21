using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Practical_18.Interfaces;
using Practical_18.Models;


namespace Practical_18.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        string serverError = "Internal server error";
        string nullValueError = "Student details are null";
        string invalidDetails = "Student details are invalid";
        string notFoundError = "Student not found";

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<IActionResult> GetSingleStudent(int id)
        {
            try
            {
                var result = await _studentService.GetStudentById(id);

                if (result is null)
                {
                    return NotFound(notFoundError);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, serverError);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Students>> GetAllStudents()
        {
            return await _studentService.GetAllStudents();

        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody]  Students students)
        {
            try
            {
                if (students is null)
                {
                    return BadRequest(nullValueError);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(invalidDetails);
                }
                var result = await _studentService.AddStudent(students);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500,serverError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatStudent([FromBody] Students student)
        {
            try
            {
                if (student is null)
                {
                    return BadRequest(nullValueError);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(invalidDetails);
                }

                var result = await _studentService.UpdateStudent(student);
                if (result is null)
                {
                    return NotFound(notFoundError);

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, serverError);
            } 
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {  
                var result = await _studentService.DeleteStudent(id);
                if (result is null)
                {
                    return NotFound(notFoundError);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, serverError);
            }
        }
    }
}
