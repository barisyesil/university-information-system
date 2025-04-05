using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using universityınfırmationsystem.Models;

namespace universityınfırmationsystem.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private static List<Student> students = new List<Student>
    {
        new Student {
            Id = 44488883333,
            Name = "Ernin Talip Demirkiran",
            Email = "etd@eskisehir.edu.tr",
            Courses = new List<string> { "BIM308", "BIM439" }
        },
         new Student {
            Id = 31651664686,
            Name = "Barış Yeşildağ",
            Email = "barisyesil621@gmail.com",
            Courses = new List<string> { "BIM308", "BIM439" ,"BIM447" }
        },
          new Student {
            Id = 48758648788,
            Name = "Alkım Can Aytaç",
            Email = "alkmct@gmail.com",
            Courses = new List<string> { "BIM439", "BIM447" }
        }
    };

        // GET api/students
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllStudents()
        {
            return Ok(students);
        }

        // GET api/students/44488883333
        [HttpGet]
        [Route("{id:long}")]
        public IHttpActionResult GetStudent(long id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST api/students
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (students.Any(s => s.Id == student.Id))
            {
                return Conflict();
            }

            students.Add(student);
            return Created($"api/students/{student.Id}", student);
        }

        // PUT api/students/44488883333
        [HttpPut]
        [Route("{id:long}")]
        public IHttpActionResult UpdateStudent(long id, [FromBody] Student student)
        {
            if (!ModelState.IsValid || id != student.Id)
            {
                return BadRequest(ModelState);
            }

            var existingStudent = students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
            existingStudent.Courses = student.Courses;

            return Ok(existingStudent);
        }

        // DELETE api/students/44488883333
        [HttpDelete]
        [Route("{id:long}")]
        public IHttpActionResult DeleteStudent(long id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            students.Remove(student);
            return Ok();
        }
    }
}