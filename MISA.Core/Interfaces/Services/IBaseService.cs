using System;
using System.Collections.Generic;

namespace MISA.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        public IEnumerable<MISAEntity> GetAll();

        public MISAEntity GetById(Guid entityId);

        public int Insert(MISAEntity entity);

        public int Update(MISAEntity entity);

        public int Delete(Guid entityId);
    }
}