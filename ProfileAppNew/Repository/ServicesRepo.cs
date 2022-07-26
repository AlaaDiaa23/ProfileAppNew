using ProfileAppNew.Data;
using ProfileAppNew.Models;

namespace ProfileAppNew.Repository
{
    public class ServicesRepo : IServicesRepo
    {
        private readonly ApplicationDBContext db;

        public ServicesRepo(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void AddService(Service service)
        {
            db.Services.Add(service);
            db.SaveChanges();
        }

        public Service GetServiceById(int id)
        {
            return db.Services.FirstOrDefault(m => m.Id == id);
        }

        public List<Service> GetServices()
        {
            return db.Services.ToList();
        }

        public void RemoveService(Service service)
        {
           db.Services.Remove(service);
            db.SaveChanges();
        }

        public void UpdateService(Service service)
        {
            db.Services.Update(service);
            db.SaveChanges();
        }
    }
}
