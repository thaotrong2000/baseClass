using System;
using System.Collections.Generic;

namespace MISA.Core.Interfaces.Services
{
    /// <summary>
    /// InterfaceBaseService là phần khung xử lý nghiệp vụ
    /// InterfaceBaseService chứa các phần chung để cho cá InterfaceService khác kế thừa
    /// Interface này nhằm xử lý nghiệp vụ
    /// Interface này xử lý database thông qua Repository
    /// Để xử lý như vậy thì ta cần gọi đến InterfaceBaseRepository hoặc các InterFace kế thừa nó
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBy: NTTHAO(5/5/2021)
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy tất cả thông tin khách hàng và kèm theo xử lý nghiệp vụ
        /// </summary>
        /// <returns>
        /// - 200: Lấy dữ liệu thành công
        /// - 204: Không lấy được dữ liệu
        /// </returns>
        public IEnumerable<MISAEntity> GetAll();

        /// <summary>
        /// Lấy thông tin khách hàng theo CustomerId
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>
        /// - 200: Lấy được thông tin khách hàng cần tìm
        /// - 204: Không lấy được thông tin khách hàng cần tìm
        /// </returns>
        public MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm một khách hàng ( Dưới dạng một object MISAEntity)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// - 201: Thêm được khách hàng thành công
        /// - 400: Không thêm được khách hàng, người dùng đã nhập sai dữ liệu
        /// - 500: Lỗi Server, liên hệ MISA để khắc phục lỗi
        /// </returns>
        public int Insert(MISAEntity entity);

        /// <summary>
        /// Cập nhật thông tin của một khách hàng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// - 200: Update khách hàng thành công
        /// - 400: Không Update được khách hàng, hãy nhập lại thông tin Customer
        /// - 500: Server bị lỗi, Xin liên hệ MISA để được khắc phục lỗi
        /// </returns>
        public int Update(MISAEntity entity);

        /// <summary>
        /// Xóa một khách hàng theo CustomerId
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>
        /// - 204: Xóa khách hàng thành công
        /// - 400: Không xóa được khách hàng, hãy nhập lại CustomerId
        /// - 500: Server bị lỗi, Xin liên hệ MISA để được khắc phục lỗi
        /// </returns>
        public int Delete(Guid entityId);
    }
}