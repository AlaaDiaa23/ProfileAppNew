using ProfileAppNew.Data;
using ProfileAppNew.Models;

namespace ProfileAppNew.Repository
{
    public class AboutRepo : IAboutRepo
    {
        private readonly ApplicationDBContext db;

        public AboutRepo(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void AddAbout(About about)
        {
            
            db.Abouts.Add(about);
            db.SaveChanges();
        }

        public void DeleteAbout(About about)
        {
            db.Abouts.Remove(about);
            db.SaveChanges();
        }

        public About GetAboutById(int id)
        {
            return db.Abouts.FirstOrDefault(m => m.Id == id);

        }

        public List<About> GetAbouts()
        {
            return db.Abouts.ToList();
        }

        public void UpdateAbout(About about)
        {
            db.Abouts.Update(about);
            db.SaveChanges();
        }
    }
}
