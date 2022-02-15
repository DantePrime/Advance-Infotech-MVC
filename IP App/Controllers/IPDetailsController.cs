using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace IP_App.Controllers
{
    public class IPDetailsController : Controller
    {
        PlanRepository db = new PlanRepository();
        
        // GET: IPDetails
        [HttpGet]
        public ActionResult ListAllPlans()
        {
            if(Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            List<DataAccess.Plan_Details> entityList = new List<DataAccess.Plan_Details>();
            List<Models.Plan_Details> mvcList = new List<Models.Plan_Details>();
            entityList = db.GetAllPlan_Details();
            foreach(DataAccess.Plan_Details entityPlan in entityList)
            {
                Models.Plan_Details mvcPlan = new Models.Plan_Details();
                mvcPlan.Plan_ID = entityPlan.Plan_ID;
                mvcPlan.Plan_Name = entityPlan.Plan_Name;
                mvcPlan.Amount = entityPlan.Amount;
                mvcPlan.Usage_Limit = entityPlan.Usage_Limit;
                mvcPlan.Speed = entityPlan.Speed;
                mvcPlan.Renewal_Duration = entityPlan.Renewal_Duration;
                mvcPlan.Subscriptions_Included = entityPlan.Subscriptions_Included;
                mvcPlan.Plan_Type = entityPlan.Plan_Type;
                mvcPlan.Installation_Charges = entityPlan.Installation_Charges;
                mvcList.Add(mvcPlan);
            }

            return View(mvcList);
        }

        [HttpGet]
        
        public ActionResult AddPlan()
        {
            if (Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPlan(Models.Plan_Details planInfo)
        {
            if (Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            if(ModelState.IsValid)
            {
                DataAccess.Plan_Details entityPlan = new DataAccess.Plan_Details()
                {
                    Plan_ID = planInfo.Plan_ID,
                    Plan_Name = planInfo.Plan_Name,
                    Plan_Type = planInfo.Plan_Type,
                    Amount = planInfo.Amount,
                    Installation_Charges = planInfo.Installation_Charges,
                    Renewal_Duration = planInfo.Renewal_Duration,
                    Speed = planInfo.Speed,
                    Subscriptions_Included = planInfo.Subscriptions_Included,
                    Usage_Limit = planInfo.Usage_Limit
                };
                bool result = db.AddPlan(entityPlan);
                if (!result)
                {
                    return View("Error");
                }
                else
                {
                    return RedirectToAction("ListAllPlans");
                }
            }
            else
            {
                return View("Error");
            }

        }

        [HttpGet]

        public ActionResult UpdatePlan(int id)
        {
            if (Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            DataAccess.Plan_Details entityPlan = db.GetPlanByID(id);
            Models.Plan_Details mvcPlan = new Models.Plan_Details()
            {
                Plan_ID = entityPlan.Plan_ID,
                Plan_Name = entityPlan.Plan_Name,
                Amount = entityPlan.Amount,
                Plan_Type = entityPlan.Plan_Type,
                Installation_Charges = entityPlan.Installation_Charges,
                Renewal_Duration = entityPlan.Renewal_Duration,
                Speed = entityPlan.Speed,
                Subscriptions_Included = entityPlan.Subscriptions_Included,
                Usage_Limit = entityPlan.Usage_Limit
            };
            return View(mvcPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePlan(Models.Plan_Details planInfo)
        {
            if (Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            DataAccess.Plan_Details entityPlan = new DataAccess.Plan_Details()
            {
                Plan_ID = planInfo.Plan_ID,
                Plan_Name = planInfo.Plan_Name,
                Plan_Type = planInfo.Plan_Type,
                Amount = planInfo.Amount,
                Installation_Charges = planInfo.Installation_Charges,
                Renewal_Duration = planInfo.Renewal_Duration,
                Speed = planInfo.Speed,
                Subscriptions_Included = planInfo.Subscriptions_Included,
                Usage_Limit = planInfo.Usage_Limit
            };
            bool result = db.UpdatePlanDetails(entityPlan);
            if (!result)
            {
                return View("Error");
            }
           
            return RedirectToAction("ListAllPlans");

        }
        [HttpGet]

        public ActionResult DetailsPlan(int id)
        {
            if (Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            DataAccess.Plan_Details entityPlan = db.GetPlanByID(id);
            Models.Plan_Details mvcPlan = new Models.Plan_Details()
            {
                Plan_ID = entityPlan.Plan_ID,
                Plan_Name = entityPlan.Plan_Name,
                Amount = entityPlan.Amount,
                Plan_Type = entityPlan.Plan_Type,
                Installation_Charges = entityPlan.Installation_Charges,
                Renewal_Duration = entityPlan.Renewal_Duration,
                Speed = entityPlan.Speed,
                Subscriptions_Included = entityPlan.Subscriptions_Included,
                Usage_Limit = entityPlan.Usage_Limit
            };
            return View(mvcPlan);
        }

        [HttpGet]

        public ActionResult DeletePlan(int id)
        {
            if (Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            DataAccess.Plan_Details entityPlan = db.GetPlanByID(id);
            Models.Plan_Details mvcPlan = new Models.Plan_Details()
            {
                Plan_ID = entityPlan.Plan_ID,
                Plan_Name = entityPlan.Plan_Name,
                Amount = entityPlan.Amount,
                Plan_Type = entityPlan.Plan_Type,
                Installation_Charges = entityPlan.Installation_Charges,
                Renewal_Duration = entityPlan.Renewal_Duration,
                Speed = entityPlan.Speed,
                Subscriptions_Included = entityPlan.Subscriptions_Included,
                Usage_Limit = entityPlan.Usage_Limit
            };
            return View(mvcPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeletePlan")]
        public ActionResult DeletePlanConfirmed(int id)
        {
            if (Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            if (ModelState.IsValid)
            {

                bool result = db.DeletePlan(id);
                if (!result)
                {
                    return View("Error");
                }
                else
                {
                    return RedirectToAction("ListAllPlans");
                }
            }
            else
            {
                return View("Error");
            }

        }

        [HttpGet]
        public ActionResult SearchPlanBySpeed()
        {
            if (Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            return View();
        }
        [HttpPost]
        public ActionResult SearchPlanBySpeed(FormCollection FC)
        {
            if (Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            TempData["speed"] = FC["speed"];
            return RedirectToAction("SearchPlanBySpeedResult");
            
        }

        [HttpGet]
        public ActionResult SearchPlanBySpeedResult()
        {
            if (Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            List<DataAccess.Plan_Details> entityList = new List<DataAccess.Plan_Details>();
            List<Models.Plan_Details> mvcList = new List<Models.Plan_Details>();
            entityList = db.SearchPlanBySpeed(Convert.ToInt32(TempData["speed"]));
            foreach (DataAccess.Plan_Details entityPlan in entityList)
            {
                Models.Plan_Details mvcPlan = new Models.Plan_Details();
                mvcPlan.Plan_ID = entityPlan.Plan_ID;
                mvcPlan.Plan_Name = entityPlan.Plan_Name;
                mvcPlan.Amount = entityPlan.Amount;
                mvcPlan.Usage_Limit = entityPlan.Usage_Limit;
                mvcPlan.Speed = entityPlan.Speed;
                mvcPlan.Renewal_Duration = entityPlan.Renewal_Duration;
                mvcPlan.Subscriptions_Included = entityPlan.Subscriptions_Included;
                mvcPlan.Plan_Type = entityPlan.Plan_Type;
                mvcPlan.Installation_Charges = entityPlan.Installation_Charges;
                mvcList.Add(mvcPlan);
            }

            return View(mvcList);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            if (Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            else
            {
                Session.RemoveAll();
                return RedirectToAction("AuthenticateUser", "User");
            }

        }

    }
}