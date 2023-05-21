using Dapper;
using Microsoft.Extensions.Configuration;
using School.Infra.Entities;
using School.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _configuration;

        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Public Methods
        public async Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentEntity> Get(int id)
        {
            var sql = "SELECT TOP 1 id [Id], nome [Name], usuario [User], senha [Password], ativo [Active] FROM aluno WITH(NOLOCK) WHERE id = @Id";
            using (var connection = GetConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<StudentEntity>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IEnumerable<StudentEntity>> GetAll()
        {
            var sql = "SELECT id [Id], nome [Name], usuario [User], senha [Password], ativo [Active] FROM aluno WITH(NOLOCK)";
            using (var connection = GetConnection())
            {
                var result = await connection.QueryAsync<StudentEntity>(sql);
                return result;
            }
        }

        public async Task<int> Insert(StudentEntity entity)
        {
            var sql = "INSERT INTO aluno (nome, usuario, senha, ativo) VALUES (@Name, @User, @Password, @Active)";
            using (var connection = GetConnection())
            {
                var result = await connection.ExecuteAsync(sql, entity);

                return result;
            }
        }

        public async Task<int> Update(StudentEntity entity)
        {
            var sql = "UPDATE aluno SET nome = @Name,  usuario = @User, senha = @Password, ativo = @Active WHERE id = @Id";
            using (var connection = GetConnection())
            {
                var result = await connection.ExecuteAsync(sql, entity);

                return result;
            }
        }

        public async Task<int> UpdateStatus(bool active, params int[] id)
        {
            var sql = "UPDATE aluno SET ativo = @Active WHERE id = @Id";
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
