using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using universityınfırmationsystem.Models;

namespace universityınfırmationsystem.Controllers
{
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {
        private static List<Course> courses = new List<Course>
    {
        new Course { Id = "BIM308", Title = "Web Server Programming", Classroom = "B6" },
        new Course { Id = "BIM439", Title = "Advanced Programming", Classroom = "B7" },
        new Course { Id = "BIM447", Title = "Deep Learning", Classroom = "B8" }
    };

        // GET api/courses
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllCourses()
        {
            return Ok(courses);
        }

        // GET api/courses/BIM308
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCourse(string id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // POST api/courses
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (courses.Any(c => c.Id == course.Id))
            {
                return Conflict();
            }

            courses.Add(course);
            return Created($"api/courses/{course.Id}", course);
        }

        // PUT api/courses/BIM308
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateCourse(string id, [FromBody] Course course)
        {
            if (!ModelState.IsValid || id != course.Id)
            {
                return BadRequest(ModelState);
            }

            var existingCourse = courses.FirstOrDefault(c => c.Id == id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            existingCourse.Title = course.Title;
            existingCourse.Classroom = course.Classroom;

            return Ok(existingCourse);
        }

        // DELETE api/courses/BIM308
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCourse(string id)
        {
            var course = courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            courses.Remove(course);
            return Ok();
        }
    }
}