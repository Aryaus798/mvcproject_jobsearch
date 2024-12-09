using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcproject_jobsearch.Models;
namespace mvcproject_jobsearch.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MVC_ProjectDBEntities dbobj = new MVC_ProjectDBEntities();
        // GET: UserLogin
        public ActionResult Login_pageload()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View(new JobSearch());
        }
        public ActionResult CompanyHome()
        {
            return View(new comVaccancy());
        }
    
    public ActionResult SubmitCompanyVacancy(comVaccancy clsobj)
        {
            if (ModelState.IsValid)
            {
                int CompId = Convert.ToInt32(Session["uid"]);
                clsobj.cid = CompId;
                dbobj.sp_Vaccancy(clsobj.cid, clsobj.jtitle, clsobj.jdesc, clsobj.skills, clsobj.exper,
                    clsobj.location, clsobj.salary, clsobj.jtype, clsobj.posteddate, clsobj.lastdate,
                    clsobj.sts);
                clsobj.msg = "Successfully Inserted";
                return RedirectToAction("CompanyHome");
            }
            return RedirectToAction("CompanyHome", clsobj);
        }
        public ActionResult Login_Click(Logincls objcls)
            {
            if (ModelState.IsValid)
            {
                var val = dbobj.sp_countID(objcls.uname, objcls.password).Single();
                if (val == 1)
                {
                    var uid = dbobj.sp_loginid(objcls.uname, objcls.password).FirstOrDefault();
                    Session["uid"] = uid;
                    var lt = dbobj.sp_logintype(objcls.uname, objcls.password).FirstOrDefault();
                    if (lt == "User")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (lt == "Company")
                    {
                        return RedirectToAction("CompanyHome");
                    }
                }
            }
            else
            {
                ModelState.Clear();
                objcls.msg = "Invalid login";
                return View("Login_pageload", objcls);
            }
            return View("Login_pageload", objcls);
        }
    }
}
