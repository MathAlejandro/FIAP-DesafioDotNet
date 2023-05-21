using School.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Interfaces
{
    public interface IStudentRepository: IBaseRepository<StudentEntity>
    {
        
    }
}
