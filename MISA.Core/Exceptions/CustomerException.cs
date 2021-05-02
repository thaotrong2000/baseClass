using System;

namespace MISA.Core.Exceptions
{
    public class CustomerException : Exception
    {
        public CustomerException(string message) : base(message)
        {
        }

        /// <summary>
        /// Kiểm tra xem dữ liệu có Null không?
        /// </summary>
        /// <param name="customerCode"></param>
        public static void CheckNullCustomerCode(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode))
            {
                var response = new
                {
                    devMsg = "Mã khách hàng không được phép để trống",
                    MISACode = "001"
                };

                throw new CustomerException(response.devMsg);
            }
        }
    }
}