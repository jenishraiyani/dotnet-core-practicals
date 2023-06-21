using System.ComponentModel.DataAnnotations;

namespace Practical_18.Models
{
    public class StudentDto
    {
        
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
