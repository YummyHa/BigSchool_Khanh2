using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BigSchool_Khanh2.Models;

namespace BigSchool_Khanh2.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        
        public bool ShowAction { get; set; }
    }
}