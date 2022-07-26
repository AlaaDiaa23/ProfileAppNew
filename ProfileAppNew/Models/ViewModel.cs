namespace ProfileAppNew.Models
{
    public class ViewModel
    {
        public IEnumerable<Information> Information { get; set; }
        public IEnumerable<About> About { get; set; }
        public IEnumerable<Service> Service { get; set; }
        public IEnumerable<Work> Work { get; set; }
    }
}
