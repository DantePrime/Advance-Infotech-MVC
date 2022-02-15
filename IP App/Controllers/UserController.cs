using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace IP_App.Controllers
{
    public class UserController : Controller
    {
        UserRepository db = new UserRepository();
        // GET: User
        [HttpGet]
        public ActionResult AuthenticateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthenticateUser(Models.UserDetails u)
        {
            if(db.ValidateUser(u.User_Emaild, u.User_Password)!= null)
            {
                Session["EmailID"] = u.User_Emaild;
                return RedirectToAction("ListAllPlans", "IPDetails");
            }
            else
            {
                ViewBag.fail = "Invaid Credentials!! Please try again";
                return View();
            }
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(Models.UserDetails u)
        {
            DataAccess.User_Details entityUser = new DataAccess.User_Details()
            {
                User_First_Name = u.User_First_Name,
                User_Last_Name = u.User_Last_Name,
                User_Emaild = u.User_Emaild,
                User_ID = u.User_ID,
                User_Password = u.User_Password
            };
            if(db.RegisterUser(entityUser))
            {
                ViewBag.success = "Record added Successfully";
            }
            else
            {
                ViewBag.fail = "Record not added!! Please, Try again";
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateProfile()
        {
            if (Session["EmailID"] == null)
            {
                return RedirectToAction("AuthenticateUser", "User");
            }
            DataAccess.User_Details entityUser = db.GetUser(Convert.ToString(Session["EmailID"]));
            Models.UserDetails mvcUser = new Models.UserDetails()
            {
                User_Emaild = entityUser.User_Emaild,
                User_ID = entityUser.User_ID,
                User_First_Name = entityUser.User_First_Name,
                User_Last_Name = entityUser.User_Last_Name,
                User_Password = entityUser.User_Password
            };
            return View(mvcUser);
        }
        [HttpPost]
        [ActionName("UpdateProfile")]
        public ActionResult UpdateProfileConfirm(Models.UserDetails u)
        {
            DataAccess.User_Details entityUser = new DataAccess.User_Details()
            {
                User_First_Name = u.User_First_Name,
                User_Last_Name = u.User_Last_Name,
                User_Emaild = u.User_Emaild,
                User_ID = u.User_ID,
                User_Password = u.User_Password
            };
            bool result = db.UpdateUser(entityUser);
            if (result)
            {
                ViewBag.success = "Record updated Successfully";
            }
            else
            {
                ViewBag.fail = "Record not updated!! Please, Try again";
            }
            return View();
        }
    }
}