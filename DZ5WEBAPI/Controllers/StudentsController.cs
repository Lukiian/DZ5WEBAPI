using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.ADO;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace DZ5WEBAPI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Repository repository;

        public StudentsController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpPost("Students")]
        public Student CreateStudent([FromBody]Student student)
        {
            repository.CreateStudent(student);
            return student;
        }

        [HttpGet("Students/{id}")]
        public ActionResult<Student> GetStudent([FromRoute]int id)
        {
            var result = repository.GetAllStudents().FirstOrDefault(s => s.Id == id);
            if (result == null)
            {
                return new NotFoundResult();
            }
            return result;
        }

        [HttpPut("Students")]
        public Student UpdateStudent([FromBody]Student student)
        {
            repository.UpdateStudent(student);
            var result = repository.GetAllStudents().FirstOrDefault(s => s.Id == student.Id);
            result = student;
            return result;
        }

        [HttpDelete("Students/{id}")]
        public ActionResult DeleteStudent(int id)
        {
            repository.DeleteStudent(id);
            return new OkResult();
        }
    }
}