using School.Application.DTO;
using School.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Interfaces
{
    public interface IClassApplication
    {
        Task<IEnumerable<ClassDTO>> List();
        Task<ClassDTO> Get(int id);

        Task<int> Create(ClassDTO studentDTO);
        Task<int> Update(ClassDTO studentDTO);

        Task<int> Deactive(int id);

        Task<IEnumerable<StudentDTO>> GetStudents(int classId);
    }
}
