using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigSchool_Khanh2.Models;
using Microsoft.AspNet.Identity;

namespace BigSchool_Khanh2.Controllers.Api
{
    
    [Authorize]
    public class CoursesController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel([FromBody]int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(c => c.Id == id && c.LecturerId == userId);

            if (course.isCanceled)
            {
                return NotFound();
            }

            course.isCanceled = true;
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
