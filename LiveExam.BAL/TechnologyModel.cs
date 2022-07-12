using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LiveExams.BAL
{
  public  class TechnologyModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Technology Name is required")]
        [Display(Name ="Technology Name")]  
        public string TechnologyName { get; set; }

        [Required(ErrorMessage ="Please fill this field")]
        [Display(Name = "Active")]
        public Nullable<bool> IsActive { get; set; }
    }
}
