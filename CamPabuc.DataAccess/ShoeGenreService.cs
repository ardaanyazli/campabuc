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
    public class ShoeGenreService : IShoeGenreService
    {
        private const string TABLE = "ShoeGenre";
        public Task<bool> Create(ShoeGenre model)
        {
            return Task.FromResult(DbExecutor.Insert(TABLE, model));
        }

        public Task<bool> Delete(int Id)
        {
            return Task.FromResult(DbExecutor.Delete(TABLE, Id));
        }

        public Task<IEnumerable<ShoeGenre>> GetAll()
        {
            return Task.FromResult(DbExecutor.QueryAll<ShoeGenre>(TABLE));
        }

        public Task<IEnumerable<ShoeGenre>> GetByFilter(Func<ShoeGenre, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ShoeGenre> GetById(int id)
        {
            return Task.FromResult(DbExecutor.GetById<ShoeGenre>(TABLE, id));
        }

        public Task<bool> Update(ShoeGenre model)
        {
            return Task.FromResult(DbExecutor.Update(TABLE, model));
        }
    }
}
