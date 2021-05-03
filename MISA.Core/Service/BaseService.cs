using MISA.Core.AttributeCustom;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MISA.Core.Service
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        private IBaseRepository<MISAEntity> _baseRepository;

        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public MISAEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        public int Insert(MISAEntity entity)
        {
            // Validate dữ liệu

            Validate(entity);
            return _baseRepository.Insert(entity);
        }

        private void Validate(MISAEntity entity)
        {
            // 1)Lấy ra tất cả Property của Class
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var property in properties)
            {
                var requiredProperties = property.GetCustomAttributes(typeof(MISARequired), true);
                var maxLengthProperties = property.GetCustomAttributes(typeof(MISAMaxLength), true);
                if (requiredProperties.Length > 0)
                {
                    // Lấy giá trị:
                    var valueProperty = property.GetValue(entity);

                    // Kiểm tra giá trị:
                    if (string.IsNullOrEmpty(valueProperty.ToString()))
                    {
                        var msgError = (requiredProperties[0] as MISARequired).MsgError;
                        if (string.IsNullOrEmpty(msgError))
                        {
                            msgError = $"Không được để trống {property.Name}";
                        }
                        throw new CustomerException(msgError);
                    }
                }

                // Check maxLength
                if (maxLengthProperties.Length > 0)
                {
                    // Lấy giá trị:
                    var propertyValue = property.GetValue(entity);
                    var maxLength = (maxLengthProperties[0] as MISAMaxLength).MaxLength;

                    // Kiểm tra giá trị:
                    if (propertyValue.ToString().Length > maxLength)
                    {
                        var msgError = (maxLengthProperties[0] as MISAMaxLength).MsgError;
                        throw new CustomerException(msgError);
                    }
                }
            }

            // 2)Xác định xem Property nào sẽ phải thực hiện Validate

            CustomValidate(entity);
        }

        protected virtual void CustomValidate(MISAEntity entity)
        {
        }

        public int Update(MISAEntity entity)
        {
            return _baseRepository.Update(entity);
        }

        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }
    }
}