﻿using System;

namespace MISA.Core.Entities
{
    public class CustomerGroup
    {
        public Guid CustomerGroupId { get; set; }
        public string CustomerGroupName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CretaedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}