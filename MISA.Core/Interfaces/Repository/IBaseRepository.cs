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
        /// <returns></returns>
        public IEnumerable<MISAEntity> GetAll();

        /// <summary>
        /// Lấy thông tin khách hàng theo CustomerId
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm một khách hàng ( Dưới dạng một object MISAEntity)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(MISAEntity entity);

        /// <summary>
        /// Cập nhật thông tin của một khách hàng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(MISAEntity entity);

        /// <summary>
        /// Xóa một khách hàng theo CustomerId
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public int Delete(Guid entityId);
    }
}