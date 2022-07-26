using ProfileAppNew.Models;

namespace ProfileAppNew.Repository
{
    public interface IinfoRepo
    {
        List<Information> GetAllInformation();
        void Add(Information info);  

        void Update(Information info);  
        Information GetById(int id);   
        void Delete(Information info);

    }
}
