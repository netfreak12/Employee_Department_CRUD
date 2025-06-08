using System.ComponentModel.DataAnnotations;
namespace MVC_CRUD_APP.Models
{
    public class Department
    {
        [Key] // Assuming you are using System.ComponentModel.DataAnnotations for the Key attribute
        public int DeptId { get; set; }

        [Required(ErrorMessage = "Department Name is required.")]
        public string DeptName { get; set; } = string.Empty; // Default to an empty string to avoid null reference issues
    }
}
