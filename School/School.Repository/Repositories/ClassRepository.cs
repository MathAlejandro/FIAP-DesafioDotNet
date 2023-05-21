using Microsoft.Extensions.Configuration;
using School.Infra.Entities;
using School.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using static Dapper.SqlMapper;

namespace School.Infra.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly IConfiguration _configuration;

        public ClassRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Public Methods

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ClassEntity> Get(int id)
        {
            var sql = "SELECT TOP 1 id [Id], curso_id [CourseId], turma[Class], ano [Year], ativo [Active] FROM turma WITH(NOLOCK) WHERE id = @Id";
            using (var connection = GetConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ClassEntity>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IEnumerable<ClassEntity>> GetAll()
        {
            var sql = "SELECT id [Id], curso_id [CourseId], turma[Class], ano [Year], ativo [Active] FROM turma WITH(NOLOCK)";
            using (var connection = GetConnection())
            {
                var result = await connection.QueryAsync<ClassEntity>(sql);
                return result;
            }
        }

        public async Task<IEnumerable<StudentEntity>> GetStudents(int classId)
        {
            var sql = @"
SELECT 
	A.id [Id],
	A.nome [Name],
	A.usuario [User],
	--A.senha [Password],
	A.ativo [Active]
FROM 
	aluno A WITH(NOLOCK)
	INNER JOIN aluno_turma AT WITH(NOLOCK) ON AT.aluno_id = A.id
WHERE
	AT.turma_id = @ClassId";

            using (var connection = GetConnection())
            {
                var result = await connection.QueryAsync<StudentEntity>(sql, new { ClassId = classId });

                return result;
            }
        }

        public async Task<bool> HasAnotherClass(string className)
        {
            var sql = "SELECT 1 FROM turma WITH(NOLOCK) WHERE turma = @Class";
            using (var connection = GetConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<int>(sql, new { Class = className });
                return result > 0;
            }
        }

        public async Task<int> Insert(ClassEntity entity)
        {
            var sql = "INSERT INTO turma (curso_id, turma, ano, ativo) VALUES (@CourseId, @Class, @Year, @Active)";
            using (var connection = GetConnection())
            {
                var result = await connection.ExecuteAsync(sql, entity);

                return result;
            }
        }

        public async Task<int> Update(ClassEntity entity)
        {
            var sql = "UPDATE turma SET curso_id = @CourseId,  turma = @Class, ano = @Year, ativo = @Active WHERE id = @Id";
            using (var connection = GetConnection())
            {
                var result = await connection.ExecuteAsync(sql, entity);

                return result;
            }
        }

        public async Task<int> UpdateStatus(bool active, params int[] id)
        {
            var sql = "UPDATE turma SET ativo = @Active WHERE id = @Id";
            using (var connection = GetConnection())
            {
                var result = await connection.ExecuteAsync(sql, new { Active = active, Id = id });

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
