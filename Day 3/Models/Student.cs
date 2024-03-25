using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Day_3.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength =2) ]
        public string Name { get; set; }
        [Range(20,30)]
        [DivideByTwoValidation(2,ErrorMessage ="U must enter age that accept division by two")]
        public int Age {  get; set; }
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+\.[a-zA-Z]{2,4}")]
        public string Email { get; set; }

        //public string Password {  get; set; }
        //[Compare("Password")]
        //[NotMapped]
        //public string Cpassword {  get; set; }
        [ForeignKey ("Department")]
        public int DepartmentId {  get; set; }
         public   Department Department { get; set; }
    }
}
