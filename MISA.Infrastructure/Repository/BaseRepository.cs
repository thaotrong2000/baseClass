using Dapper;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace MISA.Infrastructure.Repository
{
    /// <summary>
    /// Tạo xử lý với cơ sở dữ liệu
    /// Trong Base là các thành phần dùng chung của Repository
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBy: NTTHAO(5/5/2021)
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

        /// <summary>
        /// Xóa một người dùng bằng mã định danh
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>
        /// Trả về trạng thái: có bao nhiêu giá trị đã bị chịu tác động
        /// </returns>
        /// /// CreatedBy: NTTHAO(5/5/2021)
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

        /// <summary>
        /// Nhận toàn bộ danh sách khách hàng
        /// </summary>
        /// <returns>
        /// IEnumerable<MISAEntity>
        /// </returns>
        /// CreatedBy: NTTHAO(5/5/2021)
        public IEnumerable<MISAEntity> GetAll()
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                var tableName = typeof(MISAEntity).Name;
                var customerGroups = dbConnection.Query<MISAEntity>($"Proc_Get{tableName}s", commandType: CommandType.StoredProcedure);
                return customerGroups;
            }
        }

        /// <summary>
        /// Tìm kiếm khách hàng bằng CustomerId
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// /// CreatedBy: NTTHAO(5/5/2021)
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

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// Trả về xem có bao nhiêu dữ liệu chịu tác động
        /// </returns>
        /// CreatedBy: NTTHAO(5/5/2021)
        public int Insert(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                var rowsAffect = dbConnection.Execute($"Proc_Insert{tableName}",
                param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        /// <summary>
        /// Update dữ liệu người dùng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// Bao nhiêu dữ liệu đã bị chịu tác động
        /// </returns>
        /// CreatedBy: NTTHAO(5/5/2021)
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