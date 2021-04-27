using System;

namespace MISA.Core.Exceptions
{

    public class CustomerException : Exception
    {

        public static void CheckCustomerCodeEmpty(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode))
            {

            }
        }



    }
}