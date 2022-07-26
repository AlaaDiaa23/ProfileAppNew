using System.ComponentModel.DataAnnotations;

namespace ProfileAppNew.Models
{
    public class Information
    {
        public int? Id { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }=string.Empty;
        [Required]

        public string Phone { get; set; } = string.Empty;
        [Required]

        public string Location { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

    }
}
