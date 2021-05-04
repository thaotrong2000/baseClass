using MISA.Core.AttributeCustom;
using System;

namespace MISA.Core.Entities
{
    public class Customer
    {
        public Guid? CustomerId { get; set; }

        [MISARequired("Mã khách hàng không được phép để trống")]
        [MISAMaxLength(20, msg: "Mã khách hàng không được phép quá 20 ký tự")]
        public string CustomerCode { get; set; }
        
        [MISARequired]
        public string FullName { get; set; }

        public int Gender { get; set; }
        public string MemberCardCode { get; set; }
        public Guid CustomerGroupId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}