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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        // Các hàm xử lý DATABASE

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

        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            throw new NotImplementedException();
        }

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