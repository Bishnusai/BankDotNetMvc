using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LiveExams.BAL
{
  public class CandidateModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public System.DateTime BirthDate { get; set; }
        public int CollegeId { get; set; }
        //public string CollegeName { get; set; }
        public int QualificationId { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public int PositionId { get; set; }
        public int TechForTraining { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public System.DateTime RegisDate { get; set; }
        public Nullable<System.DateTime> ExamDate { get; set; }
        public string QueID { get; set; }
        public Nullable<decimal> Percentage { get; set; }
        public Nullable<int> TimeRemain { get; set; }
        [Display(Name = "ExamComplete ")]
        public bool IsExamComplete { get; set; }
        [Display(Name ="Active")]
        public Nullable<bool> IsActive { get; set; }
        public LiveExams.DAL.College College { get; set; }
        public List<CollegeModel> CollegeList { get; set; }



    }
}
