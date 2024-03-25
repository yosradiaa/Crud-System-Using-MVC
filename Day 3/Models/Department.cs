using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_3.Models
{
   
    public class Department
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Remote("CheckDeptId","Department")]

        public int DeptId { get; set; }
        [Remote("CheckDeptName", "Department")]

        public string Name { get; set; }
        public bool Status { get; set; } = true;

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }

}
