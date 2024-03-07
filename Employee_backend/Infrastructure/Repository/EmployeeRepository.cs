using Core.Entities;
using Core.Interfaces.Services;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services;
using static Dapper.SqlMapper;
using Infrastructure.Interfaces;
using System.Data;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        IDbContextMaria _dbContext;
        public EmployeeRepository(IDbContextMaria dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Employee> getSearching(int pageSize, int page, string search)
        {

            var query = $"SELECT * FROM Employee " +
                $" WHERE (PhoneNumber LIKE @search OR EmployeeCode LIKE @search OR FullName LIKE @search)" +
                $" LIMIT @limit OFFSET @start";

            var parameters = new DynamicParameters();
            parameters.Add("@search", $"%{search}%", DbType.String);
            parameters.Add("@limit", pageSize);
            parameters.Add("@start", page * pageSize);

            var res = _dbContext.Connection.Query<Employee>(query, parameters);
            return res;
        }
        public int getSearch(string search)
        {
            var query = $"SELECT * FROM Employee " +
            $" WHERE (PhoneNumber LIKE @search OR EmployeeCode LIKE @search OR FullName LIKE @search)";


            var parameters = new DynamicParameters();
            parameters.Add("@search", $"%{search}%", DbType.String);

            var res = _dbContext.Connection.Query<Employee>(query, parameters);
            return res.Count();
        }
        public IEnumerable<Employee> getPaging(int pageSize, int page)
        {

            var query = $"SELECT * FROM Employee LIMIT @limit OFFSET @start";

            var parameters = new DynamicParameters();

            parameters.Add("@limit", pageSize);
            parameters.Add("@start", page * pageSize);
            var res = _dbContext.Connection.Query<Employee>(query, parameters);
            return res;
        }

        public string newEmployeeCodeBigger()
        {
            var sql = "SELECT MAX(e.EmployeeCode) FROM Employee e";
            var paramters = new DynamicParameters();
            return _dbContext.Connection.QueryFirstOrDefault<string>(sql, paramters);

        }
    }

}

