using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcproject_jobsearch.Models
{
    public class CheckBoxListHelper
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class UserReg
    {
        public List<CheckBoxListHelper> MyFavoriteQual { get; set; }
        public string[] selectedQual { get; set; }
        [Required(ErrorMessage = "**")]
        public string name { set; get; }
        [Range(18, 50, ErrorMessage = "Enter the age")]
        public int age { set; get; }
        [Required(ErrorMessage = "Enter the Address")]
        public string address { set; get; }
        [EmailAddress(ErrorMessage = "Enter valid email id")]
        public string email { set; get; }
        [Required(ErrorMessage = "Enter the Contact Number!")]
        public string phone { set; get; }
        [Required(ErrorMessage = "Enter the Location!")]
        public string location { set; get; }
        public string gen { set; get; }
        public string qua { set; get; }
        [Required(ErrorMessage = "Enter the Skills!")]
        public string skills { set; get; }
        public string expr { set; get; }
        public string photo { set; get; }
        public string uname { set; get; }
        public string pwd { set; get; }
        [Compare("pwd", ErrorMessage = "Password mismatch")]
        public string cpwd { set; get; }
        public string umsg { set; get; }
    }
}
    