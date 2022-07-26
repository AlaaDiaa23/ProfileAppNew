using ProfileAppNew.Models;

namespace ProfileAppNew.Repository
{
    public interface IWorkRepo
    {
        List<Work> GetWorks();
     
        Work GetWorkById(int id);  
        void Add(Work work);    
        void Update(Work work);
        void Delete(Work work);
    }
}
