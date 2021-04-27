using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using MySqlConnector;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        // Các hàm xử lý DATABASE

        public bool CheckCustomerCodeExist(string customerCode)
        {
            return true;

        }

        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            throw new NotImplementedException();
        }

    }
}
