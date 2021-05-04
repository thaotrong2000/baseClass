using System;
using System.Collections.Generic;

namespace MISA.Core.Interfaces.Repository
{
    /// <summary>
    /// Base Interface Repository: Cung cấp các phương thức, thuộc tính sử dụng chung
    /// của Interface Repository
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBy: NTTHAO(4/5/2021)
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ thông tin khách hàng
        /// </summary>
        /// <returns>
        /// - 200: Lấy thông tin khách hàng thành công
        /// - 204: Không lấy được thông tin khách hàng
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
        /// - 200: Xóa khách hàng thành công
        /// - 400: Không xóa được khách hàng, hãy nhập lại CustomerId
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