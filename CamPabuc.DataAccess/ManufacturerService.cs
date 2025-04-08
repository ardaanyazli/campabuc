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
    public class ManufacturerService : IManufacturerService
    {
        private const string TABLE = "Manufacturer";
        public Task<bool> Create(Manufacturer model)
        {
            return Task.FromResult(DbExecutor.Insert(TABLE, model));
        }

        public Task<bool> Delete(int Id)
        {
            return Task.FromResult(DbExecutor.Delete(TABLE, Id));
        }

        public Task<IEnumerable<Manufacturer>> GetAll()
        {
            return Task.FromResult(DbExecutor.QueryAll<Manufacturer>(TABLE));
        }

        public Task<IEnumerable<Manufacturer>> GetByFilter(Func<Manufacturer, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Manufacturer> GetById(int id)
        {
            return Task.FromResult(DbExecutor.GetById<Manufacturer>(TABLE, id));
        }

        public Task<bool> Update(Manufacturer model)
        {
            return Task.FromResult(DbExecutor.Update(TABLE, model));
        }
    }
}
