using School.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Interfaces
{
    public interface IClassRepository: IBaseRepository<ClassEntity>
    {

        Task<bool> HasAnotherClass(string className);

        Task<IEnumerable<StudentEntity>> GetStudents(int classId);
    }
}
