using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcproject_jobsearch.Models;
namespace mvcproject_jobsearch.Controllers
{
    public class UserAppController : Controller
    {
        MVC_ProjectDBEntities dbobj = new MVC_ProjectDBEntities();
        // GET: UserApp
        public ActionResult ApplyCV_Load()
        {
            return View();
        }
        public ActionResult Applycv_click(UserApplication clsobj, HttpPostedFileBase file, int jid)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/resume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\resume", fname);
                    clsobj.resume = fullpath; // 
                }
                int UserId = Convert.ToInt32(Session["uid"]);
                clsobj.uid = UserId;
                clsobj.jid = jid;
                dbobj.sp_userapplication(clsobj.jid, clsobj.uid, clsobj.appldate, clsobj.resume, "Applied");
                clsobj.msg = "Applied Successfully";
                return View("ApplyCV_Load", clsobj);
            }
            return View("ApplyCV_Load", clsobj);
        }

    }
}
