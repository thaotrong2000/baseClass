using MISA.Core.AttributeCustom;
using System;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin về khách hàng
    /// </summary>
    /// CreatedBy: NTTHAO(4/5/2021)
    public class Customer
    {
        /// <summary>
        /// Mã định danh khách hàng tự sinh (Guid)
        /// </summary>
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [MISARequired("Mã khách hàng không được phép để trống")]
        [MISAMaxLength(20, msg: "Mã khách hàng không được phép quá 20 ký tự")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        [MISARequired]
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Số thẻ khách hàng
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Số định danh Group của khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Số điện thoại khách hàng
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ngày sinh khách hàng
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Tên công ty của khách hàng
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế công ty của khách hàng
        /// </summary>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Địa chỉ Email của khách hàng
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Ngày tạo thông tin khách hàng
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo thông tin khách hàng
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa thông tin khách hàng
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa thông tin khách hàng
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}