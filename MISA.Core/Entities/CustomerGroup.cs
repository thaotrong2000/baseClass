using MISA.Core.AttributeCustom;
using System;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin về nhóm khách hàng
    /// </summary>
    /// CreatedBy: NTTHAO(4/5/2021)
    public class CustomerGroup
    {
        /// <summary>
        /// Số định danh Group của khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên Group của khách hàng
        /// </summary>
        [MISARequired("Tên nhóm khách hàng không được phép để trống")]
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Miêu tả thông tin nhóm khách hàng
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ngày tạo nhóm khách hàng
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo nhóm khách hàng
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa nhóm khách hàng
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa nhóm khách hàng
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}