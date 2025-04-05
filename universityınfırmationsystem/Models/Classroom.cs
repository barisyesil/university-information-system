using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace universityınfırmationsystem.Models
{
    public class Classroom
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
    }
}