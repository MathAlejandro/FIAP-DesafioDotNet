using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Entities
{
    public class ClassEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Class { get; set; }
        public int Year { get; set; }
        public bool Active { get; set; }
    }
}