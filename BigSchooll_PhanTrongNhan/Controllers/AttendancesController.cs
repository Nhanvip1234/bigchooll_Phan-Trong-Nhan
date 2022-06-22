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
    [Authorize]
   
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendenceDto attendenceDto)
        {
            var UserId = User.Identity.GetUserId();
            if (_dbContext.Attendences.Any(a => a.AttendeeId == UserId && a.CourseId == attendenceDto.CourseId))
                return BadRequest("The Attendance already exists!");
            var attendance = new Attendence
            {
                CourseId = attendenceDto.CourseId,
                AttendeeId = UserId
            };
            _dbContext.Attendences.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
