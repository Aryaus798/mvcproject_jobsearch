using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcproject_jobsearch.Models
{
    public class JobSearch
    {
        public JobSearch()
        {
            selectjob = new List<jsearch>();
            insertse = new jsearch();
        }
        public jsearch insertse { get; set; }
        public List<jsearch> selectjob { set; get; }
    }
    public class jsearch
    {
        public int Job_Id { get; set; }
        public int Company_Id { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public string Location { get; set; }
        public string Job_Status { get; set; }
        public string Last_Date { get; set; }
        public string jobmsg { get; set; }
    }
    
}