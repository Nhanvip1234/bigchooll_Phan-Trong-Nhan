using BigSchooll_PhanTrongNhan.DTOs;
using BigSchooll_PhanTrongNhan.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchooll_PhanTrongNhan.Controllers
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
            var UserId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FolloweeId == UserId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Foloowing already exists!");
            var following = new Following
            {
                FolloweeId = followingDto.FolloweeId,
                FollowerId = UserId
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
