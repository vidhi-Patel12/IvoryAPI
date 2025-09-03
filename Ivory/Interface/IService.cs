using Ivory.Models;

namespace Ivory.Interface
{
    public interface IService
    {
        Task<int> CreateService(Service service);
        Task<Service> GetServiceById(int id);
        Task<IEnumerable<Service>> GetAllServices();
        Task UpdateService(Service service);
        Task DeleteService(int id);

        Task<Service?> GetServiceByName(string serviceName);

    }
}
