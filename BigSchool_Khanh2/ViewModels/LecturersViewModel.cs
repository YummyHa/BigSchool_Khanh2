using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BigSchool_Khanh2.Models;

namespace BigSchool_Khanh2.ViewModels
{
    public class LecturersViewModel
    {
        public IEnumerable<ApplicationUser> FollowingLecturers { get; set; }

        public bool ShowAction { get; set; }
    }
}