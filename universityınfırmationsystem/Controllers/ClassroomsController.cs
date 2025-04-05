using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using universityınfırmationsystem.Models;

namespace universityınfırmationsystem.Controllers
{
    [RoutePrefix("api/classrooms")]
    public class ClassroomsController : ApiController
    {
        private static List<Classroom> classrooms = new List<Classroom>
    {
        new Classroom { Id = "B6", Description = "Computer Engineering Ground Floor", Capacity = 60 },
        new Classroom { Id = "B7", Description = "Computer Engineering Second Floor", Capacity = 65 },
        new Classroom { Id = "B8", Description = "Computer Engineering Ground Floor", Capacity = 55 }
    };

        // GET api/classrooms
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllClassrooms()
        {
            return Ok(classrooms);
        }

        // GET api/classrooms/B6
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetClassroom(string id)
        {
            var classroom = classrooms.FirstOrDefault(c => c.Id == id);
            if (classroom == null)
            {
                return NotFound();
            }
            return Ok(classroom);
        }
    }
}