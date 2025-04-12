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
    public class ShoeColorService : IShoeColorService
    {
        private const string TABLE = "ShoeColor";
        public Task<bool> Create(ShoeColor model)
        {
            return Task.FromResult(DbExecutor.Insert(TABLE, model));
        }

        public Task<bool> Delete(int Id)
        {
            return Task.FromResult(DbExecutor.Delete(TABLE, Id));
        }

        public Task<IEnumerable<ShoeColor>> GetAll()
        {
            return Task.FromResult(DbExecutor.QueryAll<ShoeColor>(TABLE));
        }

        public Task<IEnumerable<ShoeColor>> GetByFilter(Func<ShoeColor, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ShoeColor> GetById(int id)
        {
            return Task.FromResult(DbExecutor.GetById<ShoeColor>(TABLE, id));
        }

        public Task<bool> Update(ShoeColor model)
        {
            return Task.FromResult(DbExecutor.Update(TABLE, model));
        }
    }
}
