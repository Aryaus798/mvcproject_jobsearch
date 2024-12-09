using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcproject_jobsearch.Models
{
    public class comVaccancy
    {
        public int cid { set; get; }
        [Required(ErrorMessage = "Enter the Job Title")]
        public string jtitle { set; get; }
        [Required(ErrorMessage = "Required Field")]
        public string jdesc { set; get; }
        [Required(ErrorMessage = "Required Field")]
        public string skills { set; get; }
        [Required(ErrorMessage = "Required Field")]
        public string exper { set; get; }
        [Required(ErrorMessage = "Required Field")]
        public string location { set; get; }
        [Required(ErrorMessage = "Required Field")]
        public string salary { set; get; }
        [Required(ErrorMessage = "Required Field")]
        public string jtype { set; get; }
        [Required(ErrorMessage = "Required Field")]
        public DateTime posteddate { set; get; }
        [Required(ErrorMessage = "Required Field")]
        public DateTime lastdate { set; get; }
        [Required(ErrorMessage = "Required Field")]
        public string sts { set; get; }
        public string msg { set; get; }
    }
}