using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*=================Domain Layer===================*/
namespace Cls_Model
{
    public class AdminInfo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string FName { get; set; }
        [MaxLength(20)]
        public string LName { get; set; }
        public DateTime JoiningDate { get; set; }
        public string DeptName { get; set; }
        public string LoginId { get; set; }
        public string LoginPass { get; set; }
        public string Active { get; set; } = "Y";
    }
    public class EmployeeTypeMaster
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Type Name Is Needed")]
        public string Name { get; set; }
    }
    public class EmployeeMaster
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        [Required(ErrorMessage ="First Name Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }
        [MaxLength(200)]
        public string ImgPath { get; set; }
        [Required]
        public string Password { get; set; }
        public float Age { get; set; }
        public DateTime JoiningDate { get; set; }
        [ForeignKey(nameof(EmployeeTypeMaster))]
        [Required]
        public int TypeId { get; set; }
        [Required]
        public char Active { get; set; } = 'Y';
        public EmployeeTypeMaster? EmpType { get; set; }
    }

}
