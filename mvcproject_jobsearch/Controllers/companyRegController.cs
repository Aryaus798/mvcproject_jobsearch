using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcproject_jobsearch.Models;
namespace mvcproject_jobsearch.Controllers
{
    public class companyRegController : Controller
    {
        MVC_ProjectDBEntities dbobj = new MVC_ProjectDBEntities();
        // GET: companyReg
        public ActionResult CompanyReg_pageload()
        {
            return View();
        }
        public ActionResult Insertcompany_click(companyRegcls clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_maxidlogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_comInsert(regid, clsobj.comName, clsobj.comEmail, clsobj.comPhone,
                    clsobj.Location, clsobj.comWebsite);
                dbobj.sp_logininsert(regid, clsobj.comusername, clsobj.compassword, "Company");
                clsobj.companymsg = "Inserted";
                return View("CompanyReg_pageload", clsobj);
            }
            return View("CompanyReg_pageload", clsobj);
        }
    }
}