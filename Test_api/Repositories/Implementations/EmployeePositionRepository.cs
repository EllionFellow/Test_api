using Dapper;
using System;
using System.Data;
using Test_api.DO;
using Test_api.Repositories.Interfaces;

namespace Test_api.Repositories.Implementations
{
    /// <summary>
    /// Implementation of IEmployeePositionRepository
    /// <see cref="IEmployeePositionRepository"/>
    /// </summary>
    public class EmployeePositionRepository : IEmployeePositionRepository
    {
        #region DI

        private readonly IDbConnection _db;

        public EmployeePositionRepository(IDbConnection db)
        {
            _db = db;
        }

        #endregion

        /// <inheritdoc/>
        public void DeleteEmployeePosition(DbEmployeePosition employeePosition)
        {
            _db.Execute("DELETE FROM employeeposition WHERE \"employeeid\" = @employeeId AND \"positionid\" = @positionId", employeePosition);
        }

        /// <inheritdoc/>
        public bool IsPositionOccupied(Guid positionId)
        {
            var con = _db.QuerySingle<int>("SELECT COUNT (employeeid) FROM employeeposition WHERE positionid = @positionId", new { positionId });
            return con != 0;
        }

        /// <inheritdoc/>
        public void NewEmployeePosition(DbEmployeePosition employeePosition)
        {
            _db.Execute("INSERT INTO employeeposition VALUES (@EmployeeId, @PositionId)", employeePosition);
        }

        /// <inheritdoc/>
        public void DeleteEmployee(Guid id)
        {
            _db.Execute("DELETE FROM employeeposition WHERE \"employeeid\" = @id", new { id });
        }

        /// <summary>
        /// Connection disposal
        /// </summary>
        ~EmployeePositionRepository()
        {
            _db.Dispose();
        }
    }
}
