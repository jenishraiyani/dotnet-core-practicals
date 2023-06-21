using System.ComponentModel.DataAnnotations;

namespace Practical17.Models
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        
        [Required] 
        public string StudentName { get; set;}

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set;}

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string Phone { get; set;}
        
        [Required]
        public string Address { get; set;}
      
    }
}
