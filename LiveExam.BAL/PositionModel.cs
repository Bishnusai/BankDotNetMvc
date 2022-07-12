using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LiveExams.BAL
{
   public class PositionModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Required Position Name")]
        [Display(Name ="Position Name")]
        public string NAME { get; set; }

        [Display(Name = "Time Minutes")]
        public Nullable<int> TIMEMINUTES { get; set; }

        [Required(ErrorMessage ="Plz select True Or Not")]
        [Display(Name = "Active")]
        public Nullable<bool> ISACTIVE { get; set; }

        [Required(ErrorMessage ="Plz choose Technology")]
        [Display(Name = "Technology Id")]
        public Nullable<int> TechnologyId { get; set; }

        public TechnologyModel Technology { get; set; }
        public List<TechnologyModel> TechList { get; set; }
    }
}
