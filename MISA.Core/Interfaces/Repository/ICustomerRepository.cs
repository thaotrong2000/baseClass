using MISA.Core.Entities;
using System.Collections.Generic;

namespace MISA.Core.Interfaces.Repository
{
    /// <summary>
    /// InterfaceCustomerRepository thể hiện cho CustomerRepository
    /// Interface này kế thừa những gì chung nhất từ IBaseRepository
    /// Interface này Custom thêm một vài tính chất của riêng nó, như phần dưới
    /// <typeparam name="MISAEntity">
    /// Interface:IBaseRepository<MISAEntity>
    /// Trong bài này: MISAEntity là: Customer
    /// </summary>
    /// CreatedBy: NTTHAO(4/5/2021)
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// Check CustomerCode đã tồn tại chưa?
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>
        /// - true: CustomerCode đã tồn tại ()
        /// - false: CustomerCode chưa tồn tại
        /// </returns>
        /// CreatedBy: NTTHAO(4/5/2021)
        public bool CheckCustomerCodeExist(string customerCode);

        /// <summary>
        /// Check số điện thoại đã tồn tại hay chưa?
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>
        /// - true: Số điện thoại đã tồn tại ( Không thể thêm )
        /// - false: Số điện thoại chưa tồn tại ( Có thể thêm )
        /// </returns>
        public bool CheckPhoneNumberExist(string phoneNumber);

        /// <summary>
        /// Lọc dữ liệu và phân trang theo các điều kiện
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="fullName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns>
        /// - Trả về dữ liệu nếu có dữ liệu phù hợp
        /// - Trả về nội dung trống nếu không có dữ liệu
        /// - Trả về lỗi nếu người dùng nhập sai dữ liệu hoặc trả về lỗi Server
        /// </returns>
        public IEnumerable<Customer> CustomerFilter(int pageIndex, int pageSize, string fullName, string phoneNumber);
    }
}