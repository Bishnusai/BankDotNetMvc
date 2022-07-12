using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LiveExams.BAL
{
   public class UsersModels
    {
        public long UserID { get; set; }

        [Required]
        [Display(Name = "User Name ")]
        public string UserName { get; set; }

        [Display(Name = "Display Name ")]
        public string DisplayName { get; set; }

        [Required]
        [Display(Name ="Active")]
        public Nullable<bool> IsActive { get; set; }


        [Required(ErrorMessage ="Please Enter correct Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
