using MISA.Core.Entities;

namespace MISA.Core.Interfaces.Repository
{
    /// <summary>
    /// InterfaceCustomerGroupRepository thể hiện cho CustomerGroupRepository
    /// Interface này kế thừa những gì chung nhất từ IBaseRepository
    /// Interface này Custom thêm một vài tính chất của riêng nó, như phần dưới ( up to date)
    /// <typeparam name="MISAEntity">
    /// Interface: IBaseRepository<MISAEntity>
    /// Trong interface này: MISAEnity là CustomerGroup
    /// </summary>
    /// CreatedBy: NTTHAO(4/5/2021)
    public interface ICustomerGroupRepository : IBaseRepository<CustomerGroup>
    {
    }
}