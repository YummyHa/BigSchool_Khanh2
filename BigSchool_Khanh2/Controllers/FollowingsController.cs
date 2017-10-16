using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigSchool_Khanh2.DTOs;
using BigSchool_Khanh2.Models;
using Microsoft.AspNet.Identity;

namespace BigSchool_Khanh2.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
            {
                return BadRequest("Following Already Exist!!");
            }

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId,
            };

            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollowee(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();

            var following = new Following
            {
                FolloweeId = followingDto.FolloweeId,
                FollowerId = userId,
            };

            _dbContext.Entry(following).State = EntityState.Deleted;
            _dbContext.SaveChanges();

            return Ok();
        }

    }
}
