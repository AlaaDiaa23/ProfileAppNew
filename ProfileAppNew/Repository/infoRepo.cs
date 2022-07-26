using ProfileAppNew.Data;
using ProfileAppNew.Models;

namespace ProfileAppNew.Repository
{
    public class infoRepo : IinfoRepo
    {
        private readonly ApplicationDBContext db;

        public infoRepo(ApplicationDBContext db)
        {
            this.db = db;
        }

        public void Add(Information info)
        {
           db.Information.Add(info);
            db.SaveChanges();
        }

        public void Delete(Information info)
        {
            var item = db.Information.FirstOrDefault(m=>m.Id==info.Id);
            if(item != null)
            {
                db.Information.Remove(item);
                db.SaveChanges();
            }
        }

        public List<Information> GetAllInformation()
        {
            return db.Information.OrderByDescending(m => m.Id).ToList();
        }

        public Information GetById(int id)
        {
           return db.Information.Find(id);
            
        }

        public void Update(Information info)
        {
            db.Information.Update(info);
            db.SaveChanges();
        }
    }
}
