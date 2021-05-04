using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;

namespace MISA.Infrastructure.Repository
{
    /// <summary>
    /// Xử lý dữ liệu cho CustomerGroup
    /// Các hàm xử lý chung được kết thừa thông qua lớp BaseRepository
    /// Custom thêm các hàm riêng của CustomerGroup
    /// </summary>
    public class CustomerGroupRepository : BaseRepository<CustomerGroup>, ICustomerGroupRepository
    {
    }
}