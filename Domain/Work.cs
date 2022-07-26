using System.ComponentModel.DataAnnotations;

namespace ProfileAppNew.Models
{
    public class Work
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;
    }
}
