using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcproject_jobsearch.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace mvcproject_jobsearch.Controllers
{
    public class jobsearchController : Controller
    {
        MVC_ProjectDBEntities dbobj = new MVC_ProjectDBEntities();
        // GET: jobsearch
        public ActionResult searchjob_pageload()
        {
            return View(Getdata());
        }
        private JobSearch Getdata()
        {
            var joblist = new JobSearch();
            List<string> lst = new List<string>();
            var job = dbobj.CompJobVacc_Tab.ToList();
            foreach(var e in job)
            {
                var jobcls = new jsearch();
                jobcls.Job_Id = e.Job_Id;
                jobcls.Company_Id = e.Company_Id;
                jobcls.Skills = e.Skills;
                jobcls.Experience = e.Experience;
                jobcls.Location = e.Location;
                jobcls.Job_Status = e.Status;
                jobcls.Last_Date = e.Last_Date.ToString();
                joblist.selectjob.Add(jobcls);
                var s = jobcls.Skills;
                lst.Add(s);
                TempData["ski"] = string.Join(" ", lst);
            }
            return joblist;
        }
        public ActionResult searchjob_click(JobSearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Skills))
            {
                qry += " and Skills like '%" + clsobj.insertse.Skills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Experience))
            {
                qry += " and Experience like '%" + clsobj.insertse.Experience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Location))
            {
                qry += " and Location like '%" + clsobj.insertse.Location + "%'";
            }
            return View("searchjob_pageload",getdata1(clsobj,qry));
        }
        private JobSearch getdata1(JobSearch clsobj, string qry)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();
                while (dr.Read())
                {
                    var jobcls = new jsearch();
                    jobcls.Job_Id = Convert.ToInt32(dr["Job_Id"].ToString());
                    jobcls.Company_Id = Convert.ToInt32(dr["Company_Id"].ToString());
                    jobcls.Skills = dr["Skills"].ToString();
                    jobcls.Experience = dr["Experience"].ToString();
                    jobcls.Location = dr["Location"].ToString();
                    jobcls.Job_Status = dr["Status"].ToString();
                    jobcls.Last_Date = dr["Last_Date"].ToString();
                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }
    }
}