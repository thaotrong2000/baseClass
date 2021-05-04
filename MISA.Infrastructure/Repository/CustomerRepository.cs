using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MISA.Infrastructure.Repository
{
    /// <summary>
    /// Tạo xử lý dữ liệu của riêng Customer
    /// Kế thừa toàn bộ các hàm xử lý chung của BaseRepository
    /// </summary>
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Kiểm tra code đã tồn tại hay chưa?
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>
        /// - true: CustomerCode đã tồn tại ( Không thể thêm )
        /// - false: CustomerCode chưa tồn tại ( Có thể thêm )
        /// </returns>
        public bool CheckCustomerCodeExist(string customerCode)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_CustomerCode", customerCode);
                var customerCodeExist = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return customerCodeExist;
            }
        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại chưa?
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>
        /// - true: SĐT đã tồn tại (Không thể thêm)
        /// - false: SĐT chưa tồn tại (Có thể thêm)
        /// </returns>
        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Thực hiện lọc dữ liệu theo số dữ liệu cần thiết, theo FullName, theo SĐT
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="fullName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns>
        /// customerFilter: Danh sách các Customer
        /// </returns>
        public IEnumerable<Customer> CustomerFilter(int pageIndex, int pageSize, string fullName, string phoneNumber)
        {
            using (dbConnection = new MySqlConnection(connectString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_PageIndex", pageIndex);
                dynamicParameters.Add("@m_PageSize", pageSize);
                dynamicParameters.Add("@fullName", fullName);
                dynamicParameters.Add("@phoneNumber", phoneNumber);
                var customerFilter = dbConnection.Query<Customer>("Proc_CustomerFilter", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return customerFilter;
            }
        }
    }
}