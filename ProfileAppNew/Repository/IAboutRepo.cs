using ProfileAppNew.Models;

namespace ProfileAppNew.Repository
{
    public interface IAboutRepo
    {
        List<About>GetAbouts();
        void AddAbout(About about); 
        void UpdateAbout(About about);
      void DeleteAbout(About about);    
        About GetAboutById(int id); 
    }
}
