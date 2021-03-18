using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using Test_api.Entity;

namespace Test_api.Repositories.Impl
{
    /// <summary>
    /// Implementation of IPositionRepository
    /// </summary>
    public class PositionRepository : IPositionRepository
    {
        public IConfiguration Configuration { get; }
        private readonly string dbConnect;
        public PositionRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            dbConnect = Configuration.GetConnectionString("dbConnection");
        }

        ///<inheritdoc/>
        public IEnumerable<DbPosition> GetPositions(Guid id)
        {
            using IDbConnection db = new NpgsqlConnection(dbConnect);
            try
            {
                return db.Query<DbPosition>(@"SELECT id, name, grade FROM position");
            }
            catch (Exception) { return null; }
        }

        ///<inheritdoc/>
        public Guid? NewPosition(string name, int grade)
        {
            using IDbConnection db = new NpgsqlConnection(dbConnect);
            Guid id = Guid.NewGuid();
            DbPosition pos = new DbPosition(id, name, grade);
            try
            {
                db.Execute(@"INSERT INTO position 
                           VALUES (@Id, @Name, @Grade)", pos);
                return id;
            }
            catch (Exception)
            {
                return null;
            }
        }

        ///<inheritdoc/>
        public bool DeletePosition(Guid id)
        {
            using IDbConnection db = new NpgsqlConnection(dbConnect);
            try
            {
                db.Execute("DELETE FROM position WHERE id = @id", new { id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///<inheritdoc/>
        public bool UpdatePosition(DbPosition position)
        {
            using IDbConnection db = new NpgsqlConnection(dbConnect);
            try
            {
                db.Execute(@"UPDATE position SET 
                            name = @Name, 
                            grade = @Grade, 
                            WHERE id = @Id", position);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<DbPosition> GetEmployeePositions(Guid id)
        {
            using IDbConnection db = new NpgsqlConnection(dbConnect);
            return db.Query<DbPosition>(@"SELECT p.id, p.name, p.grade FROM position As p 
                                                INNER JOIN employeegrade AS eg ON eg.positionid = p.id 
                                                WHERE eg.employeeid = @id;", new { id });
        }

        public IEnumerable<DbPosition> GetPositions()
        {
            using IDbConnection db = new NpgsqlConnection(dbConnect);
            return db.Query<DbPosition>(@"SELECT id, name, grade FROM position");
        }
    }
}
