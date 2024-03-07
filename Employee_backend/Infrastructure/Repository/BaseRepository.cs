using Dapper;
using Core.Interfaces.Infrastructure;
using Infrastructure.Interfaces;
using MySqlConnector;
using System.Text.Unicode;
using static Dapper.SqlMapper;

namespace Infrastructure.Repository
{
    public class BaseRepository<Entity> : IBaseRepository<Entity>, IDisposable where Entity : class
    {
        #region feild
        IDbContext _dbContext;

        #endregion
        #region constructor
        public BaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Cancel sqlconnection after not use
        /// </summary>
        /// @date: 25/12/23
        /// @author: htthuy
        public void Dispose()
        {
            //Console.WriteLine("connection is closed!!!");
            //extend IDisposable
            _dbContext.Connection?.Dispose();
        }

        #endregion
        #region method
        public int Delete(Guid entityCode)
        {

            // Get the entity's class name dynamically
            var className = typeof(Entity).Name;

            // Construct the SQL DELETE command using a parameterized query
            var sqlCommand = $"DELETE FROM {className} WHERE {className}Id = @id";

            // Create a DynamicParameters object to hold the parameter values
            var parameters = new DynamicParameters();

            // Add the parameter value for the entity entityCode
            parameters.Add("@id", entityCode);
            // Execute the DELETE command using the database context's connection
            var res = _dbContext.Connection.Execute(sqlCommand, parameters);

            // Return the number of rows affected by the DELETE operation
            return res;
        }

        public IEnumerable<Entity> GetAll()
        {
            // 1. get class name of entity
            var className = typeof(Entity).Name;
            // 2. thực hiện truy vấn dữ liệu trong database
            var list = _dbContext.Connection.Query<Entity>($"SELECT * FROM {className}");
            // 3. return list entity
            return list;
        }

        public Entity GetById(Guid entityId)
        {
            // 1. get class name of entity
            var className = typeof(Entity).Name;

            // 2. thực hiện truy vấn dữ liệu trong database
            var command = $"SELECT * FROM {className}  WHERE  {className}Id = \"{entityId}\" ";

            // 3. return list entity
            return _dbContext.Connection.QueryFirstOrDefault<Entity>(command);
        }
        public Entity GetByCode(string entityCode)
        {
            var className = typeof(Entity).Name;
            var command = $"SELECT * FROM {className}  WHERE  {className}Code = \"{entityCode}\" ";
            Entity entity = _dbContext.Connection.QueryFirstOrDefault<Entity>(command);
            return entity;
        }
        public int Insert(Entity entity)
        {
            var className = typeof(Entity).Name;
            var query = $"INSERT INTO {className}  " +
                $"({string.Join(",", entity.GetType().GetProperties().Select(p => p.Name))}) " +
                $"VALUES ({string.Join(",", entity.GetType().GetProperties().Select(p => $"@{p.Name}"))})";

            var parameters = new DynamicParameters();


            foreach (var item in entity.GetType().GetProperties())
            {
                parameters.Add($"@{item.Name}", item.GetValue(entity));
            }

            var res = _dbContext.Connection.Execute(query, parameters);
            return res;
        }

        public int Update(Entity entity, Guid entityId)
        {
            var className = typeof(Entity).Name;
            //commad for SQL
            var query = $"UPDATE {className} SET" +
                $" {string.Join(",", entity.GetType().GetProperties().Skip(1).Select(p => $"{p.Name} = @{p.Name}"))}" +
                $" WHERE {className}Id = @{className}Id";

            var parameters = new DynamicParameters();

            // Add parameters to the command
            foreach (var item in entity.GetType().GetProperties().Skip(1).Where(p => p.Name != $"{className}Id"))
            {
                parameters.Add($"@{item.Name}", item.GetValue(entity));
            }
            parameters.Add($"@{className}Id", entityId);
            var res = _dbContext.Connection.Execute(query, parameters);
            return res;

            //throw new NotImplementedException();
        }
        #endregion
    }
}
