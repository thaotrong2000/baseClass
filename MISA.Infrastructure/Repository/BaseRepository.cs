using Dapper;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace MISA.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        protected string connectString = "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database = MF0_NVManh_CukCuk02;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "AllowZeroDateTime=True"
                ;

        protected IDbConnection dbConnection;
        private string tableName = typeof(MISAEntity).Name;

        public int Delete(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}Id", entityId);
                var customers = dbConnection.Execute($"Proc_Delete{tableName}",
                    param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }

        public IEnumerable<MISAEntity> GetAll()
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                var tableName = typeof(MISAEntity).Name;
                var customerGroups = dbConnection.Query<MISAEntity>($"Proc_Get{tableName}s", commandType: CommandType.StoredProcedure);
                return customerGroups;
            }
        }

        public MISAEntity GetById(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}Id", entityId);
                var customer = dbConnection.QueryFirstOrDefault<MISAEntity>($"Proc_Get{tableName}ById",
                    param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public int Insert(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                var rowsAffect = dbConnection.Execute($"Proc_Insert{tableName}",
                param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        public int Update(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                // Update data

                var updateCustomer = dbConnection.Execute($"Proc_Update{tableName}", param: entity,
                    commandType: CommandType.StoredProcedure);
                return updateCustomer;
            }
        }
    }
}