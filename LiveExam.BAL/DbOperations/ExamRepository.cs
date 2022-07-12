using LiveExams.DAL;
using LiveExams.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace LiveExams.BAL.DbOperations
{
    public  class ExamRepository
    {
        LiveExamEntities db = new LiveExamEntities();
       
        //Register user
        public long RegisterUser(UsersModels model)
        {
            User UserData = new User()
            {
                UserName = model.UserName,
                Password = model.Password,
                DisplayName=model.DisplayName,
                IsActive=model.IsActive
            };

            db.Users.Add(UserData);
            db.SaveChanges();
            return UserData.UserID;

        }


        public UsersModels UserLogin(string userName, string password)
        {
            var objUser = db.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

            UsersModels objUserModel = new UsersModels();

            if (objUser != null)
            {
                objUserModel.UserID = objUser.UserID;
                objUserModel.UserName = objUser.UserName;
                objUserModel.DisplayName= objUser.DisplayName;

            }

            return objUserModel;
            //throw new UnauthorizedAccessException("Invalid User Details");
            //return email;
        }

        
        public List<UsersModels> GetAllUserData()
        {

            List<UsersModels> GetUserData = db.Users.Select(x => new UsersModels()
            {
                UserID  = x.UserID,
                UserName = x.UserName,
                DisplayName= x.DisplayName,
                Password=x.Password,
                IsActive=x.IsActive

            }).ToList();
            return GetUserData;

        }


        //get User data by id
        public UsersModels GetSingleDataByUserId(int id)
        {
            var result = db.Users.Where(x => x.UserID == id).Select(x => new UsersModels()
            {
                UserID = x.UserID,
                UserName = x.UserName,
                DisplayName = x.DisplayName,
                Password = x.Password,
                //IsActive = x.IsActive
            }).FirstOrDefault();
            return result;
        }

      

        //update branchData
        public bool UpdateUserData(long id, UsersModels model)
        {
            //int Userid= Convert.ToInt32( id);

            User GetUser = db.Users.FirstOrDefault(x => x.UserID == id);

            if (GetUser != null)
            {
                GetUser.UserID = model.UserID;
                GetUser.UserName = model.UserName;
                GetUser.DisplayName = model.DisplayName;
                GetUser.IsActive = model.IsActive;
                GetUser.Password = model.Password;
            }
            db.SaveChanges();
            return true;
        }
       


        //Register College
        public int RegisterCollege(CollegeModel model)
        {
            College CollegeData = new College()
            {
                CollegeName = model.CollegeName,
                University= model.University,
                IsActive =Convert.ToBoolean( model.IsActive)
            };

            db.Colleges.Add(CollegeData);
            db.SaveChanges();
            return CollegeData.Id;

        }
       

        //List of college data
        public List<CollegeModel> GetAllCollegeData(CollegeModel model)
        {
            List<CollegeModel> GetCollegeData = db.Colleges.Select(x => new CollegeModel()
            {
                Id = x.Id,
                CollegeName = x.CollegeName,
                University = x.University,
                IsActive = x.IsActive

            }).ToList();


            return GetCollegeData;
        }

        //get single data of college
        public CollegeModel getSingleDatabyCollegeid(int id)
        {
            var result = db.Colleges.Where(x => x.Id == id).Select(x => new CollegeModel()
            {
                Id = x.Id,
                CollegeName = x.CollegeName,
                University = x.University,
                IsActive = x.IsActive
            }).FirstOrDefault();
            return result;
        }

        //edit of college data
        public bool UpdateCollegeData(int id, CollegeModel model)
        {
            College Getcollege = db.Colleges.FirstOrDefault(x => x.Id == id);
            if (Getcollege != null)
            {
                Getcollege.Id = model.Id;
                Getcollege.CollegeName = model.CollegeName;
                Getcollege.University = model.University;
                Getcollege.IsActive = Convert.ToBoolean(model.IsActive);
            }
            db.SaveChanges();
            return true;
        }

        public List<Candidate> GetAllCandidateRecord()

        {
            return db.Candidates.OrderByDescending(x=>x.Id).ToList();
        }


        public int RegisterTechnology(TechnologyModel model)
        {
            Technology techData = new Technology()
            {
                TechnologyName = model.TechnologyName,
                isActive = Convert.ToBoolean(model.IsActive),
            };
            db.Technologies.Add(techData);
            db.SaveChanges();
            return techData.Id;
        }
        //list of technology
        public List<TechnologyModel> GetAllTechnoData()
        {

            List<TechnologyModel> GetTechData = db.Technologies.Select(x => new TechnologyModel()
            {
              Id=x.Id,
              TechnologyName=x.TechnologyName,
              IsActive=x.isActive
            }).ToList();
            return GetTechData;

        }

       
        //get single technology data by id
        public TechnologyModel GetSingleTechById(int id)
        {
            TechnologyModel result = db.Technologies.Where(x => x.Id == id).Select(x => new TechnologyModel()
            {
                Id = x.Id,
                TechnologyName = x.TechnologyName,
                IsActive = x.isActive
            }).FirstOrDefault();
            return result;

        }
       
        //edit the technology data and save 
        public bool UpdateTechnology(TechnologyModel model, int id)
        {
            Technology GetTech = db.Technologies.FirstOrDefault(x => x.Id == id);
            if (GetTech != null)
            {
                GetTech.Id = model.Id;
                GetTech.TechnologyName = model.TechnologyName;
                GetTech.isActive = Convert.ToBoolean(model.IsActive);

            }
            db.SaveChanges();
            return true;


        }

       
        public PositionModel AddPosition(PositionModel model)
        {
            Position positionData = new Position()
            {
                TechnologyId = model.TechnologyId,
                ID = model.ID,
                Name = model.NAME,
                TimeMinutes = model.TIMEMINUTES,
                IsActive = model.ISACTIVE,
                
            };
            db.Positions.Add(positionData);
            db.SaveChanges();
            return model;
        }

       

        //dropdown for user with account binding
        public List<TechnologyModel> TechNameDropDown()
        {
            List<TechnologyModel> result = new List<TechnologyModel>();

            var list = db.Technologies.Select(m => m).ToList();

            if (list != null && list.Count() > 0)
            {
                foreach (var data in list)
                {
                    TechnologyModel model = new TechnologyModel()
                    {
                        Id = data.Id,
                        TechnologyName=data.TechnologyName,
                        IsActive=data.isActive
                       
                    };
                    result.Add(model);
                }
            }
            return result;
        }

       

        public List<PositionModel> GetAllPositionData()
        {
            List<PositionModel> GetPosData = db.Positions.Select(x => new PositionModel()
            {
                ID=x.ID,
                NAME = x.Name,
                TechnologyId = x.TechnologyId,
                ISACTIVE = x.IsActive,
                TIMEMINUTES = x.TimeMinutes,
                Technology = new TechnologyModel
                {
                    TechnologyName=x.Technology.TechnologyName
                }
            }).ToList();
            return GetPosData;
        }
       

        public PositionModel GetPosDataById(int id)
        {
            PositionModel result = db.Positions.Where(x => x.ID == id).Select(x => new PositionModel()
            {
                ID = x.ID,
                NAME = x.Name,
                TIMEMINUTES=x.TimeMinutes,
                TechnologyId = x.TechnologyId,
                ISACTIVE = x.IsActive,
                Technology = new TechnologyModel
                {
                    TechnologyName = x.Technology.TechnologyName
                }
            }).FirstOrDefault();
            return result;
        }
       
        public bool UpdatePosition(PositionModel model, int id)
        {
            Position GetPos = db.Positions.FirstOrDefault(x => x.ID == id);
            if (GetPos != null)
            {
                GetPos.ID = model.ID;
                GetPos.Name = model.NAME;
                GetPos.TechnologyId = model.TechnologyId;
                GetPos.TimeMinutes = model.TIMEMINUTES;
                GetPos.IsActive = model.ISACTIVE;
            }
            db.SaveChanges();
            return true;
        }
       
        //QuestionCategory list
        public List<QuestionCategoryModel> GetAllQuesCategory()
        {
            List<QuestionCategoryModel> GetQuesCatData = db.QuestionCategories.Select(x => new QuestionCategoryModel()
            {
                CategoryID = x.CategoryID,
                Name = x.Name,
                TimeMinutes=x.TimeMinutes,
                IsActive = x.IsActive,

            }).ToList();
            return GetQuesCatData;
        }

        //list of posquejoin table
        public List<PosQueJoinModel> GetAllPosQuesData()
        {
            List<PosQueJoinModel> GetPosQues = db.PosQueJoins.Select(x => new PosQueJoinModel()
            {
                ID = x.ID,
                PositionID = x.PositionID,
                QueCatID = x.QueCatID,
                NoOfQuestion = x.NoOfQuestion,
                IsActive = x.IsActive,
                Position = new PositionModel
                {
                    ID = x.Position.ID,
                    NAME = x.Position.Name
                },
                QuestionCategory = new QuestionCategoryModel
                {
                    CategoryID = x.QuestionCategory.CategoryID,
                    Name = x.QuestionCategory.Name
                }
            }).ToList();
            return GetPosQues;
        }
       

        public PosQueJoinModel AddPosQueJoin(PosQueJoinModel model)
        {
            PosQueJoin posqueData = new PosQueJoin()
            {
                ID = model.ID,
                PositionID = model.PositionID,
                QueCatID = model.QueCatID,
                IsActive = model.IsActive,
                NoOfQuestion=model.NoOfQuestion
            };
            db.PosQueJoins.Add(posqueData);
            db.SaveChanges();
            return model;
        }
       
        //dropdown for position binding with PosQueJoin
        public List<PositionModel> PosNameDropDown()
        {
            List<PositionModel> result = new List<PositionModel>();
            var list = db.Positions.Select(m => m).ToList();
            if (list != null && list.Count() > 0)
            {
                foreach (var data in list)
                {
                    PositionModel model = new PositionModel()
                    {
                        ID = data.ID,
                        NAME = data.Name,
                        TIMEMINUTES = data.TimeMinutes,
                        ISACTIVE = data.IsActive,
                        TechnologyId = data.TechnologyId
                    };
                    result.Add(model);

                }
            }
            return result;
        }
        //dropdown for questioncategory binding with PosQueJoin
        public List<QuestionCategoryModel> QuesCatDropdown()
        {
            List<QuestionCategoryModel> Result = new List<QuestionCategoryModel>();
            var list = db.QuestionCategories.Select(m => m).ToList();
            if (list != null && list.Count() > 0)
            {
                foreach (var data in list)
                {
                    QuestionCategoryModel model = new QuestionCategoryModel()
                    {
                        CategoryID = data.CategoryID,
                        Name = data.Name,
                        TimeMinutes = data.TimeMinutes,
                        IsActive = data.IsActive

                    };
                    Result.Add(model);
                }
            }
            return Result;
        }
        //get single posquejoin data by its id
        public PosQueJoinModel GetPosQueDataById(int id)
        {
            PosQueJoinModel result = db.PosQueJoins.Where(x => x.ID == id).Select(x => new PosQueJoinModel()
            {
                ID = x.ID,
                PositionID = x.PositionID,
                QueCatID = x.QueCatID,
                NoOfQuestion = x.NoOfQuestion,
                IsActive = x.IsActive,
                Position = new PositionModel
                {
                    ID=x.Position.ID,
                    NAME = x.Position.Name
                },
                QuestionCategory = new QuestionCategoryModel
                {
                    CategoryID=x.QuestionCategory.CategoryID,
                    Name = x.QuestionCategory.Name
                }
            }).FirstOrDefault();
            return result;
        }


        // list of particular position and question category name by its id
        public List<PosQueJoinModel> GetallPositionIdData(int id)
        {
            List<PosQueJoinModel> GetDataOfPosQueDept = db.PosQueJoins.Where(x=>x.PositionID==id).Select(x=>new PosQueJoinModel()
            {
                ID = x.ID,
                PositionID = x.PositionID,
                QueCatID = x.QueCatID,
                NoOfQuestion = x.NoOfQuestion,
                IsActive = x.IsActive,
                Position = new PositionModel
                {
                    ID = x.Position.ID,
                    NAME = x.Position.Name
                },
                QuestionCategory = new QuestionCategoryModel
                {
                    CategoryID = x.QuestionCategory.CategoryID,
                    Name = x.QuestionCategory.Name
                }
            }).ToList();
            return GetDataOfPosQueDept;
        }

        //edit the posquejoin
        public bool UpdatePosQueJOin(PosQueJoinModel model, int id)
        {
            PosQueJoin GetPosQueJoin = db.PosQueJoins.FirstOrDefault(x => x.ID == id);
                
                if (GetPosQueJoin != null)
                {
                    GetPosQueJoin.ID = model.ID;
                    GetPosQueJoin.PositionID = model.PositionID;
                    GetPosQueJoin.QueCatID = model.QueCatID;
                    GetPosQueJoin.NoOfQuestion = model.NoOfQuestion; 
                    GetPosQueJoin.IsActive =Convert.ToBoolean( model.IsActive);
                }
                db.SaveChanges();
                return true;
        }
    }
}
