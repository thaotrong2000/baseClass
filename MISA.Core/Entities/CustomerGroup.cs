﻿using MISA.Core.AttributeCustom;
using System;

namespace MISA.Core.Entities
{
    public class CustomerGroup
    {
        public Guid CustomerGroupId { get; set; }

        [MISARequired("Tên nhóm khách hàng không được phép để trống")]
        public string CustomerGroupName { get; set; }

        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}