using BigSchooll_PhanTrongNhan.Models;
using BigSchooll_PhanTrongNhan.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchooll_PhanTrongNhan.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        public CoursesController()
        {
            _dbcontext = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        [HttpPost]      
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbcontext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbcontext.Courses.Add(course);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public ActionResult Create()
        {
            var ViewModel = new CourseViewModel
            {
                Categories = _dbcontext.Categories.ToList()
            };
            return View(ViewModel);
        }
    }
}