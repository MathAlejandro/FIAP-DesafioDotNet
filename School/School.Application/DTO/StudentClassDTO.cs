using School.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTO
{
    public class StudentClassDTO
    {
        public StudentClassDTO() { }
        public StudentClassDTO(StudentClassEntity entity)
        {
            this.StudentId = entity.StudentId;
            this.ClassId = entity.ClassId;
            this.Active = entity.Active;
        }
        public int StudentId { get; set; }
        public string ClassId { get; set; }
        public bool Active { get; set; }

        public StudentClassEntity ToEntity()
        {
            return new StudentClassEntity()
            {
                StudentId = this.StudentId,
                ClassId = this.ClassId,
                Active = this.Active
            };
        }
    }
}
