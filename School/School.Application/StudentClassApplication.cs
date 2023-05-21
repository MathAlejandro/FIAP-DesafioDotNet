using School.Application.DTO;
using School.Application.Interfaces;
using School.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application
{
    public class StudentClassApplication : IStudentClassApplication
    {
        private readonly IStudentClassRepository _studentClassRepository;
        public StudentClassApplication(IStudentClassRepository studentClassRepository)
        {
            _studentClassRepository = studentClassRepository;
        }

        public async Task<int> Create(StudentClassDTO studentClassDTO)
        {
            var result = await _studentClassRepository.Insert(studentClassDTO.ToEntity());
            return result;
        }

        public async Task<int> Deactive(int studentId, int classId)
            => await _studentClassRepository.UpdateStatus(false, studentId, classId);

        public async Task<IEnumerable<StudentClassDTO>> List()
            => (await _studentClassRepository.GetAll()).Select(entity => new StudentClassDTO(entity));
    }
}
