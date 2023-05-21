using School.Application.DTO;
using School.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Interfaces
{
    public  interface IStudentApplication
    {
        Task<IEnumerable<StudentDTO>> List();
        Task<StudentDTO> Get(int id);

        Task<int> Create(StudentDTO studentDTO);
        Task<int> Update(StudentDTO studentDTO);

        Task<int> Deactive(int id);
    }
}
