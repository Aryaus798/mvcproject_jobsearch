using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcproject_jobsearch.Models
{
    public class Logincls
    {
        [Required(ErrorMessage = "Enter the username")]
        public string uname { set; get; }
        [Required(ErrorMessage = "Enter the Password")]
        public string password { set; get; }
        public string msg { set; get; }
        public string ltype { set; get; }
    }
}