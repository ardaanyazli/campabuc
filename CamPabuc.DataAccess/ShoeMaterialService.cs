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
    public class ShoeMaterialService : IShoeMaterialService
    {
        private const string TABLE = "ShoeMaterial";
        public Task<bool> Create(ShoeMaterial model)
        {
            return Task.FromResult(DbExecutor.Insert(TABLE, model));
        }

        public Task<bool> Delete(int Id)
        {
            return Task.FromResult(DbExecutor.Delete(TABLE, Id));
        }

        public Task<IEnumerable<ShoeMaterial>> GetAll()
        {
            return Task.FromResult(DbExecutor.QueryAll<ShoeMaterial>(TABLE));
        }

        public Task<IEnumerable<ShoeMaterial>> GetByFilter(Func<ShoeMaterial, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ShoeMaterial> GetById(int id)
        {
            return Task.FromResult(DbExecutor.GetById<ShoeMaterial>(TABLE, id));
        }

        public Task<bool> Update(ShoeMaterial model)
        {
            return Task.FromResult(DbExecutor.Update(TABLE, model));
        }
    }
}
