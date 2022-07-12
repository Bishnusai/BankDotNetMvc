using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LiveExams.BAL
{
   public class QuestionCategoryModel
    {
        public long CategoryID { get; set; }
        [Display(Name ="Question Dept ")]
        public string Name { get; set; }
        [Display(Name ="Time Minutes")]
        public Nullable<int> TimeMinutes { get; set; }
        [Display(Name ="Active")]
        public Nullable<bool> IsActive { get; set; }
    }
}
