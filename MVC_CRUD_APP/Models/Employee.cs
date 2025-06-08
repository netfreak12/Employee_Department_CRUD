using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CRUD_APP.Models
{
    public class Employee
    {
        [Key] // Assuming you are using System.ComponentModel.DataAnnotations for the Key attribute
        public int EmpId { get; set; }

        [Required, StringLength(30)] 
        [Display(Name = "First Name")] // Display attribute for better UI representation
        public string EmpFirstName { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Last Name")]
        public string EmpLastName { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Email Address")]
        public string EmailId { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; } // Nullable DateTime to allow for optional birth date

        [Required, StringLength(15)]
        [Display(Name = "Gender")]
        public string EmpGender { get; set; }

        [Required, StringLength(15)]
        [Display(Name = "Phone Number")] 
        public string EmpPhoneNumber { get; set; }

        [Required, Range(0, int.MaxValue)] // Assuming Salary is a non-negative integer
        public int Salary { get; set; }

        public bool EmpStatus { get; set; }

        [ForeignKey("Department")]
        [Required(ErrorMessage = "Please Select Department")]
        public int DeptId { get; set; } // Foreign key to the Department model

        public Department? Department { get; set; } // Navigation property to the Department model



    }
}
