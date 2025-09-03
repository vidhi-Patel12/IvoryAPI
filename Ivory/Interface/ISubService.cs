using Ivory.Models;

namespace Ivory.Interface
{
    public interface ISubService
    {
        Task<int> CreateSubService(SubService subService);
        Task UpdateSubService(SubService subService);
        Task DeleteSubService(int id);
        Task<SubService?> GetSubServiceById(int id);
        Task<SubService?> GetSubServiceByName(string subServiceName);
        Task<IEnumerable<SubService>> GetAllSubServices();
    }
}
