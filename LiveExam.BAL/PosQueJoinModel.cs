using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LiveExams.BAL
{
    public class PosQueJoinModel
    {
        public int ID { get; set; }
        [Display(Name = "Position Name")]
        public string PositionName { get; set; }


        [Required(ErrorMessage = "Plz choose Position")]
        public int PositionID { get; set; }

        [Required(ErrorMessage = "Plz choose Question")]
        public long QueCatID { get; set; }

        [Required(ErrorMessage ="Plz Enter the no Questions")]
        [Display(Name ="No of Questions")]
        public Nullable<int> NoOfQuestion { get; set; }

        [Required(ErrorMessage ="Plz Choose Status")]
        [Display(Name ="Active")]
        public Nullable<bool> IsActive { get; set; }

        public int TotalQues { get; set; }

        public PositionModel Position { get; set; }
        public List<PositionModel> PosList { get; set; }

        public QuestionCategoryModel QuestionCategory { get; set; }
        public List<QuestionCategoryModel> QuesCategoryList { get; set; }

       public class PosQueJoinModelPosition
        {
            public IReadOnlyList<PosQueJoinModel> TotalQues { get; set; }
            public decimal Total { get; set; }
        }

    }
}
