﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseMangmentSystemWeb.Models
{
    public class Instructor:Super
    {
        [Key]
        public int Id { get; set; }
        public int Salary { get; set; }
        [ForeignKey(nameof(Department))]
        [Required]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
