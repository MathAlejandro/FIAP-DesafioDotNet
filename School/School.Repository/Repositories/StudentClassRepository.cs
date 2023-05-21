using Microsoft.Extensions.Configuration;
using School.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using School.Infra.Entities;

namespace School.Infra.Repositories
{
    public class StudentClassRepository : IStudentClassRepository
    {
        private readonly IConfiguration _configuration;

        public StudentClassRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        #region Public Methods


        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Entities.StudentClassEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Entities.StudentClassEntity>> GetAll()
        {
            var sql = "SELECT aluno_id [StudentId], turma_id [ClassId], ativo [Active] FROM aluno_turma WITH(NOLOCK)";
            using (var connection = GetConnection())
            {
                var result = await connection.QueryAsync<StudentClassEntity>(sql);
                return result;
            }
        }

        public async Task<int> Insert(Entities.StudentClassEntity entity)
        {
            var sql = "INSERT INTO aluno_turma (aluno_id, turma_id, ativo) VALUES (@StudentId, @ClassId, @Active)";
            using (var connection = GetConnection())
            {
                var result = await connection.ExecuteAsync(sql, entity);

                return result;
            }
        }

        public Task<int> Update(Entities.StudentClassEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateStatus(bool active, params int[] id)
        {
            var sql = "UPDATE aluno_turma SET ativo = @Active WHERE aluno_id = @StudentId AND turma_id = @ClassId";
            using (var connection = GetConnection())
            {
                var result = await connection.ExecuteAsync(sql, new { Active = active, StudentId = id[0], ClassId = id[1] });

                return result;
            }
        }
        #endregion


        #region Auxiliary Methods
        private IDbConnection GetConnection()
            => new SqlConnection(_configuration.GetConnectionString("SqlServer"));
        #endregion
    }
}
