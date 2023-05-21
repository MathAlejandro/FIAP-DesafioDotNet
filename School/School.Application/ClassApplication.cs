using School.Application.DTO;
using School.Application.Interfaces;
using School.Infra.Interfaces;
using School.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application
{
    public class ClassApplication : IClassApplication
    {
        private readonly IClassRepository _classRepository;

        public ClassApplication(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        #region Public Methods
        public async Task<int> Create(ClassDTO classDTO)
        {
            if (classDTO.Year < DateTime.Now.Year)
                throw new ArgumentException("The system does not allow creating Classes with dates prior to the current one");

            if (await _classRepository.HasAnotherClass(classDTO.Class))
                throw new ArgumentException("System does not allow Classes with the same name");

            return await _classRepository.Insert(classDTO.ToEntity());
        }

        public async Task<int> Deactive(int id)
            => await _classRepository.UpdateStatus(false, id);

        public async Task<ClassDTO> Get(int id)
        {
            var result = await _classRepository.Get(id);

            return result != null ? new ClassDTO(await _classRepository.Get(id)) : null;
        }

        public async Task<IEnumerable<StudentDTO>> GetStudents(int classId)
            => (await _classRepository.GetStudents(classId))?.Select(student => new StudentDTO(student));

        public async Task<IEnumerable<ClassDTO>> List()
            => (await _classRepository.GetAll()).Select(entity => new ClassDTO(entity));

        public async Task<int> Update(ClassDTO studentDTO)
            => await _classRepository.Update(studentDTO.ToEntity());
        #endregion

    }
}
