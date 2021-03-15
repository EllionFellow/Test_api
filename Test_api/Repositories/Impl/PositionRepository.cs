using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Test_api.Entity;

namespace Test_api.Repositories.Impl
{
    /// <summary>
    /// Implementation of IPositionRepository
    /// </summary>
    public class PositionRepository : IPositionRepository
    {
        public IConfiguration Configuration { get; }
        private string dbConnect;
        public PositionRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            dbConnect = Configuration.GetConnectionString("dbConnection");
        }

        ///<inheritdoc/>
        public IEnumerable<DBPosition> GetPositions()
        {
            using (IDbConnection db = new NpgsqlConnection(dbConnect))
            {
                try
                {
                    return db.Query<DBPosition>("SELECT * FROM position");
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        ///<inheritdoc/>
        public Guid? NewPosition(string name, int grade)
        {
            using (IDbConnection db = new NpgsqlConnection(dbConnect))
            {
                Guid id = Guid.NewGuid();
                DBPosition pos = new DBPosition(id, name, grade);
                try
                {
                    db.Execute("INSERT INTO position VALUES (@Id, @Name, @Grade)", pos);
                    return id;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        ///<inheritdoc/>
        public bool DeletePosition(Guid id)
        {
            using (IDbConnection db = new NpgsqlConnection(dbConnect))
            {
                try
                {
                    db.Execute("DELETE FROM position WHERE \"id\" = @Id", new { id });
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        ///<inheritdoc/>
        public bool UpdatePosition(DBPosition position)
        {
            using (IDbConnection db = new NpgsqlConnection(dbConnect))
            {
                try
                {
                    db.Execute("UPDATE position SET " +
                        "\"Name\" = @Name, " +
                        "\"Grade\" = @Grade, " +
                        "WHERE \"id\" = @Id", position);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
