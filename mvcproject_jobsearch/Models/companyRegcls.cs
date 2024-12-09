using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcproject_jobsearch.Models
{
    public class companyRegcls
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string comName { get; set; }
        [EmailAddress(ErrorMessage = "Enter valid Email")]
        public string comEmail { get; set; }
        [Required(ErrorMessage = "Enter Valid Number")]
        public string comPhone { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Location {   get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string comWebsite { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string comusername { set; get; }
        public string compassword { set; get; }
        [Compare("compassword", ErrorMessage = "Password mismatch")]
        public string cpassword { set; get; }
        public string companymsg { set; get; }
    }
}