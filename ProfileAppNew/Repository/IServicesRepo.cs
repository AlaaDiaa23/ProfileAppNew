using ProfileAppNew.Models;

namespace ProfileAppNew.Repository
{
    public interface IServicesRepo
    {
        List<Service> GetServices();
        void AddService(Service service);
        void RemoveService(Service service);
        Service GetServiceById(int id);
        void UpdateService(Service service);
    }
}
