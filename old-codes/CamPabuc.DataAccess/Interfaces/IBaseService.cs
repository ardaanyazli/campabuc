using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamPabuc.Model.Interfaces;

namespace CamPabuc.DataAccess.Interfaces
{
    public interface IBaseService<T,VM> where T : IEntity
    {
        public Task<IEnumerable<VM>> GetAll();
        public Task<VM> GetById(int id);
        public Task<bool> Create(T model);
        public Task<bool> Update(T model);
        public Task<bool> Delete(int Id);
    }
}
