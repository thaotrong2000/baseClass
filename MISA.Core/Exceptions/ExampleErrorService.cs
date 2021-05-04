using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Exceptions
{
     public class ExampleErrorService
    {
        public void ExampleErrors()
        {
            // a custom app exception that will return a 400 response
            throw new CustomerException("Email or password is incorrect");

            // a key not found exception that will return a 404 response
            throw new KeyNotFoundException("Account not found");
        }
    }
}
