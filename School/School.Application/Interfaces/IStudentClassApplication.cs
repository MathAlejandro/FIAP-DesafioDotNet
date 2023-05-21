using School.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Interfaces
{
    public interface IStudentClassApplication
    {
        Task<IEnumerable<StudentClassDTO>> List();

        Task<int> Create(StudentClassDTO studentClassDTO);

        Task<int> Deactive(int studentId, int classId);
    }
}
