using campabuc.model;

namespace campabuc.data.interfaces;

public interface IManufacturerRepository : IRepository<Manufacturer>
{
    public Task<int> AddManufacturer();
    public Task<bool> UpdateManufacturer();
    public Task<bool> DeleteManufacturer();
}
