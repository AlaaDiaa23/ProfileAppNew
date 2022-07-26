using ProfileAppNew.Data;
using ProfileAppNew.Models;

namespace ProfileAppNew.Repository
{
    public class WorkRepo : IWorkRepo
    {
        private readonly ApplicationDBContext db;

        public WorkRepo(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(Work work)
        {
            db.Works.Add(work);
            db.SaveChanges();
        }

        public void Delete(Work work)
        {
            db.Works.Remove(work);
            db.SaveChanges();
        }

        public Work GetWorkById(int id)
        {
            return db.Works.FirstOrDefault(m => m.Id == id);
        }

        public List<Work> GetWorks()
        {
            return db.Works.ToList();
        }

        public void Update(Work work)
        {
            db.Works.Update(work);
            db.SaveChanges();
        }
    }
}
