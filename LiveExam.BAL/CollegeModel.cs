using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveExams.BAL
{
   public class CollegeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Plz Enter College  Name")]
        [Display(Name = "College Name ")]
        public string CollegeName { get; set; }

        [Required(ErrorMessage = "Plz Enter University Name")]
        [Display(Name = "University Name ")]
        public string University { get; set; }
        [Required]
        [Display(Name ="Active")]
        public bool? IsActive { get; set; }
        public CandidateModel Candidate { get; set; }
        //public string Url { get; set; }

    }
}
