using BigSchooll_PhanTrongNhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigSchooll_PhanTrongNhan.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}