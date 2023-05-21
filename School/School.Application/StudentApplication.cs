using Microsoft.Extensions.Configuration;
using School.Application.DTO;
using School.Application.Helper;
using School.Application.Interfaces;
using School.Infra.Entities;
using School.Infra.Interfaces;
using School.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application
{
    public class StudentApplication : IStudentApplication
    {
        private readonly IConfiguration _configuration;
        private readonly IStudentRepository _studentRepository;

        public StudentApplication(IConfiguration configuration, IStudentRepository studentRepositry)
        {
            _configuration = configuration;
            _studentRepository = studentRepositry;
        }

        public async Task<int> Create(StudentDTO studentDTO)
        {
            var entity = studentDTO.ToEntity();
            entity.Password = SecurityHelper.Hash(entity.Password);

            return await _studentRepository.Insert(entity);
        }

        public async Task<int> Deactive(int id)
            => await _studentRepository.UpdateStatus(false, id);

        public async Task<StudentDTO> Get(int id)
        {
            var result = await _studentRepository.Get(id);

            return result != null ? new StudentDTO(await _studentRepository.Get(id)) : null;
        }

        public async Task<IEnumerable<StudentDTO>> List()
            => (await _studentRepository.GetAll()).Select(entity => new StudentDTO(entity));

        public async Task<int> Update(StudentDTO studentDTO)
        {
            var entity = studentDTO.ToEntity();
            entity.Password = SecurityHelper.Hash(entity.Password);

            return await _studentRepository.Update(entity);
        }
    }
}
