using School.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTO
{
    public class StudentDTO
    {
        public StudentDTO() { }
        internal StudentDTO(StudentEntity studentEntity)
        {
            //if (studentEntity == null)
            //    return;

            this.Id = studentEntity.Id;
            this.Name = studentEntity.Name;
            this.User = studentEntity.User;
            this.Password = studentEntity.Password;
            this.Active = studentEntity.Active;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public StudentEntity ToEntity()
        {
            return new StudentEntity()
            {
                Id = Id,
                Name = Name,
                User = User,
                Password = Password,
                Active = Active
            };
        }
    }
}
