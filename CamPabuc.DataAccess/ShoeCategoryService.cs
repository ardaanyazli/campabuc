using CamPabuc.DataAccess.Interfaces;
using CamPabuc.Model.Entity;
using CamPabuc.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamPabuc.DataAccess
{
    public class ShoeCategoryService : IShoeCategoryService
    {
        private const string TABLE = "ShoeCategory";
        public Task<bool> Create(ShoeCategory model)
        {
            return Task.FromResult(DbExecutor.Insert(TABLE, model));
        }
        public Task<bool> Delete(int Id)
        {
            return Task.FromResult(DbExecutor.Delete(TABLE, Id));
        }

        public Task<IEnumerable<ShoeCategory>> GetAll()
        {
            return Task.FromResult(DbExecutor.QueryAll<ShoeCategory>(TABLE));
        }

        public Task<IEnumerable<ShoeCategory>> GetByFilter(Func<ShoeCategory, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ShoeCategory> GetById(int id)
        {
            return Task.FromResult(DbExecutor.GetById<ShoeCategory>(TABLE, id));
        }

        public Task<bool> Update(ShoeCategory model)
        {
            return Task.FromResult(DbExecutor.Update(TABLE, model));
        }
    }
}
