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
    /// <see cref="IPositionRepository"/>
    /// </summary>
    public class PositionRepository : IPositionRepository
    {
        #region DI

        private readonly IDbConnection _db;

        public PositionRepository(IDbConnection db)
        {
            _db = db;
        }

        #endregion

        ///<inheritdoc/>
        public IEnumerable<DbPosition> GetPositions(Guid id)
        {
                return _db.Query<DbPosition>(@"SELECT id, name, grade FROM position");
        }

        ///<inheritdoc/>
        public void NewPosition(DbPosition dbPosition)
        {
            _db.Execute(@"INSERT INTO position 
                           VALUES (@Id, @Name, @Grade)", dbPosition);
        }

        ///<inheritdoc/>
        public void DeletePosition(Guid id)
        {
            _db.Execute("DELETE FROM position WHERE id = @id", new { id });
        }

        ///<inheritdoc/>
        public void UpdatePosition(DbPosition position)
        {
                _db.Execute(@"UPDATE position SET 
                            name = @Name, 
                            grade = @Grade, 
                            WHERE id = @Id", position);
        }

        public IEnumerable<DbPosition> GetEmployeePositions(Guid id)
        {
            return _db.Query<DbPosition>(@"SELECT p.id, p.name, p.grade FROM position As p 
                                                INNER JOIN employeegrade AS eg ON eg.positionid = p.id 
                                                WHERE eg.employeeid = @id;", new { id });
        }

        public IEnumerable<DbPosition> GetPositions()
        {
            return _db.Query<DbPosition>("SELECT id, name, grade FROM position");
        }

        public DbPosition GetPosition(Guid id)
        {
            return _db.QuerySingle<DbPosition>($"SELECT id, name, grade FROM position WHERE id = @id", new { id });
        }
    }
}
