using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LiveExams.BAL.DbOperations;
using LiveExams.BAL;
using System.Web.Security;
using System.Data;
using System.IO;
using ClosedXML.Excel;
using LiveExams.DAL;

namespace ExamSystem.Controllers
{
    public class HomeController : Controller
    {
        ExamRepository  repository = null;


        public HomeController()
        {
            repository = new ExamRepository();
        }
         

        public ActionResult Index()
        {
           
            return View();
        }

        //For User Registration
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Home()
        {

            return View();
        }
        public ActionResult About()
        {

            return View();
        }
        public ActionResult ContactUs()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(UsersModels model)
        {

            if (ModelState.IsValid)
            {
                long id = repository.RegisterUser(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Message = "User Registered Successfully";
                }
            }

            return RedirectToAction("Login");
        }

        //for login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            UsersModels data = repository.UserLogin(model.UserName, model.Password);

            if (ModelState.IsValid)
            {
                
                if (data.UserID!= 0)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.message="Failure! Username and password not matched!";
                    return View();
                }
            }
            else
            {
                return View(model);
            }
        }

        //logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult GetAllUserRecords()
        {
            var GetUserRecord = repository.GetAllUserData();
            return View(GetUserRecord);
        }

        [HttpPost]
        public FileResult Export()
        {
            DataTable dt = new DataTable("UserRecords");
            dt.Columns.AddRange(new DataColumn[5]
            {
              new DataColumn("UserID"),
              new DataColumn("UserName "),
              new DataColumn("DisplayName"),
              new DataColumn("IsActive"),
              new DataColumn("Password"),

            });
            var GetUserRecord = repository.GetAllUserData();

            foreach (var user in GetUserRecord)
            {
                dt.Rows.Add(user.UserID, user.UserName, user.DisplayName, user.IsActive, user.Password);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserRecords.xlsx");
                }
            }


        }



        //Get Single Users Details
        public ActionResult GetSingleUserDetails(int id)
        {
            var GetUserRecord = repository.GetSingleDataByUserId(id);
            return View(GetUserRecord);
        }

        //Edit of User Data
        public ActionResult EditUser(int id)
        {
            var EditUser = repository.GetSingleDataByUserId(id);
            return View(EditUser);
        }
        [HttpPost]
        public ActionResult EditUser(int id, UsersModels model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateUserData(model.UserID ,model);
                return RedirectToAction("GetAllUserRecords");
            }
            return View();
        }
      
        public ActionResult CreateCollege()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateCollege(CollegeModel model)
        {

            if (ModelState.IsValid)
            {
                int id = repository.RegisterCollege(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Message = "College Registered Successfully";
                }
            }

            return RedirectToAction("");
        }

        [HttpGet]
        public ActionResult GetAllCollegeRecords(CollegeModel model)
        {
            var GetCollegeRecord = repository.GetAllCollegeData(model);
            return View(GetCollegeRecord);
        }
        //List of college records
        //[HttpPost]
        //public ActionResult GetAllCollegeRecords(CollegeModel model)
        //{
        //    var GetCollegeRecord = repository.GetAllCollegeData(model);
        //    return Json(GetCollegeRecord);
        //}
        
        //getsingle data of college
        public ActionResult GetSingleCollegeDetails(int id)
        {
            var getCollegeRecord = repository.getSingleDatabyCollegeid(id);
            return View(getCollegeRecord);
        }


        public ActionResult EditCollege(int id)
        {
            var EditCollege = repository.getSingleDatabyCollegeid(id);
            return View(EditCollege);
        }


         //Edit of college data
        [HttpPost]
        public ActionResult EditCollege(int id, CollegeModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateCollegeData(model.Id, model);
                return RedirectToAction("GetAllCollegeRecords");
            }
            return View();

        }
       // list of candidate record
        [HttpGet]
        public ActionResult GetAllCandidateRecords()
        {
            List<Candidate> GetCandidateRecord = repository.GetAllCandidateRecord();
            return View(GetCandidateRecord);
        }
        

        public ActionResult CreateTechonology()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTechonology(TechnologyModel model)
        {

            if (ModelState.IsValid)
            {
                int id = repository.RegisterTechnology(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Message = "College Registered Successfully";
                }
            }

            return RedirectToAction("GetAllTechnologyData");
        }

        //technology list
        [HttpGet]
        public ActionResult GetAllTechnologyData()
        {
            var GetTechRecord = repository.GetAllTechnoData();
            return View(GetTechRecord);
        }

        [HttpGet]
        public ActionResult GetSingleTechnologyData(int id)
        {
            var GetTechsingleRecord = repository.GetSingleTechById(id);
            return View(GetTechsingleRecord);
        }
      

        //technology edit
        [HttpGet]
        public ActionResult EditTechnology(int id)
        {
            var result = repository.GetSingleTechById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult EditTechnology(TechnologyModel model, int id)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateTechnology(model,id);
                return RedirectToAction("GetAllTechnologyData");
            }
            return View();

        }


        //Position Added     
        [HttpGet]
        public ActionResult AddPositionNewRecord()
        {
            PositionModel model = new PositionModel();
            model.TechList = repository.TechNameDropDown();
            return View(model);
        }
      
        [HttpPost]
        public ActionResult AddPositionNewRecord(PositionModel model)
        {
            PositionModel data = repository.AddPosition(model);
            if(ModelState.IsValid)
            {
                    ViewBag.Message = "Position Added successfully";
            }
            model.TechList = repository.TechNameDropDown();
            return View(model);           
        }
       
        //postion list
        [HttpGet]
        public ActionResult GetAllPosData()
        {
            var getPos = repository.GetAllPositionData();
            return View(getPos);
        }
        //get single positon data by it's id
        [HttpGet]
        public ActionResult GetSinglePositionData(int id)
        {
            var getPositionRecord = repository.GetPosDataById(id);
            return View(getPositionRecord);
        }
        //edit position data
        public ActionResult EditPosition(int id)
        {
            var result = repository.GetPosDataById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditPosition(PositionModel model, int id)
        {
            if (ModelState.IsValid)
            {
                repository.UpdatePosition(model, id);
                return RedirectToAction("GetAllPosData");

            }
            return View();
        }
       
        //questioncategory list
        [HttpGet]
        public ActionResult GetAllQueCat()
        {
            var getQueCategory = repository.GetAllQuesCategory();
            return View(getQueCategory);
        }

       
        //posQueJoin Added
        [HttpGet]
        public ActionResult AddPosQueJoin()
        {
            PosQueJoinModel model = new PosQueJoinModel();
            model.PosList = repository.PosNameDropDown();
            model.QuesCategoryList = repository.QuesCatDropdown();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddPosQueJoin(PosQueJoinModel model)
        {
            PosQueJoinModel data = repository.AddPosQueJoin(model);
            if (ModelState.IsValid)
            {
                ViewBag.Message = "PosQueJoin Added Successfully";
            }
            model.PosList = repository.PosNameDropDown();
            model.QuesCategoryList = repository.QuesCatDropdown();
            return View(model);
        }
        //list of question and positon and question category
        [HttpGet]
        public ActionResult GetAllQuesPosData()
        {
            List<PosQueJoinModel> getPosQueCat = repository.GetAllPosQuesData();
            return View(getPosQueCat);
        }
        // list of particular position and question category name by its id
        [HttpGet]
        public ActionResult GetAllPosQuesJoinCat(int id)
        {
            List<PosQueJoinModel> getPosQuesCatData = repository.GetallPositionIdData(id);
            return View(getPosQuesCatData);
        }

        //for details page
        public ActionResult GetPosQueJoinSingleData(int id)
        {
            var GetSinglePosQueJoinDat = repository.GetPosQueDataById(id); 
            return View(GetSinglePosQueJoinDat);
        }

        //edit posquejoin data
        [HttpGet]
        public ActionResult EditPosQueJoin(int? id)
        {
            var result = repository.GetPosQueDataById(Convert.ToInt16(id));
            return View(result);
        }
        [HttpPost]
        public ActionResult EditPosQueJoin(PosQueJoinModel model, int id)
        {
            
            if (ModelState.IsValid)
            {
                repository.UpdatePosQueJOin(model, id);
                return RedirectToAction("GetAllPosQuesJoinCat/"+model.PositionID);
            }
            else {
                return View();
            }
        }
    }
}