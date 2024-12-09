using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcproject_jobsearch.Models;

namespace mvcproject_jobsearch.Controllers
{
    public class UserRegController : Controller
    {
        // GET: UserReg
        MVC_ProjectDBEntities dbobj = new MVC_ProjectDBEntities();
        public ActionResult Insertuser_Pageload()
        {
            UserReg user = new UserReg();
            user.MyFavoriteQual = getQualData();
            return View(user);
        }
        public List<CheckBoxListHelper> getQualData()
        {
            List<CheckBoxListHelper> sts = new List<CheckBoxListHelper>()
            {
                new CheckBoxListHelper{Value="SSLC",Text="SSLC",IsChecked=true},
                new CheckBoxListHelper{Value="PLUS TWO",Text="PLUS TWO",IsChecked=false},
                new CheckBoxListHelper{Value="BCA",Text="BCA",IsChecked=false},
                new CheckBoxListHelper{Value="MCA",Text="MCA",IsChecked=false},
                new CheckBoxListHelper{Value="BTECH",Text="BTECH",IsChecked=false},
            };
            return sts;
        }
        public ActionResult Insert_click(UserReg clsobj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    //photo
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/photos");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\photos", fname);
                    clsobj.photo = fullpath; //set
                }
                //checkboxlist
                var quid = string.Join(",", clsobj.selectedQual);
                clsobj.qua = quid;//set
                clsobj.MyFavoriteQual = getQualData();
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
                dbobj.sp_User_reg(regid, clsobj.name, clsobj.age, clsobj.address, clsobj.email, clsobj.phone,
                    clsobj.location, clsobj.gen, clsobj.qua, clsobj.skills, clsobj.expr, clsobj.photo);
                dbobj.sp_logininsert(regid, clsobj.uname, clsobj.pwd, "User");
                clsobj.umsg = "Successfully Registered";
                return View("Insertuser_Pageload", clsobj);
            }
            else
            {
                clsobj.MyFavoriteQual = getQualData();
                return View("Insertuser_Pageload", clsobj);
            }
        }
    }
}