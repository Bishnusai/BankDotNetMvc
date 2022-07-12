using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveExams.BAL
{
   public class LoginModel
    {
        [Required(ErrorMessage = "Please Enter UserName")]
        [Display(Name = "User Name ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Correct Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
