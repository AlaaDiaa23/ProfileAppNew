using System.ComponentModel.DataAnnotations;

namespace ProfileAppNew.Models
{
    public class About
    {
        public int? Id { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }=string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]

        public string Phone { get; set; } = string.Empty;
        [Required]

        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Work { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;


    }
}
