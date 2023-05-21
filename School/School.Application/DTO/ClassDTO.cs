using School.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTO
{
    public class ClassDTO
    {
        public ClassDTO() { }
        public ClassDTO(ClassEntity classEntity)
        {
            this.Id = classEntity.Id;
            this.CourseId = classEntity.CourseId;
            this.Class = classEntity.Class;
            this.Year = classEntity.Year;
            this.Active = classEntity.Active;
        }

        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Class { get; set; }
        public int Year { get; set; }
        public bool Active { get; set; }

        public ClassEntity ToEntity()
        {
            return new ClassEntity
            {
                Id = Id,
                Active = Active,
                CourseId = CourseId,
                Class = Class,
                Year = Year
            };
        }
    }
}