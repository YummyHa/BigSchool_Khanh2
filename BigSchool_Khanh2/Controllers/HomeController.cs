using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigSchool_Khanh2.Models;
using BigSchool_Khanh2.ViewModels;
using Microsoft.AspNet.Identity;

namespace BigSchool_Khanh2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var upCommingCourses = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now);

            var attendingCourses = _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Course)
                .ToList();

            var followingLecturers = _dbContext.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();

            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = upCommingCourses,
                AttendingCourses = attendingCourses,
                FollowingLecturers = followingLecturers,
                ShowAction = User.Identity.IsAuthenticated,
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}