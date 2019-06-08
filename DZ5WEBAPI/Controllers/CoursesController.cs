using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.ADO;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace DZ5WEBAPI.Controllers
{
    public class CoursesController : ControllerBase
    {
        private readonly Repository repository;

        public CoursesController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet("Courses")]
        public List<Course> GetCourses()
        {
            var result = repository.GetAllCourses();
            return result;
        }

    }
}