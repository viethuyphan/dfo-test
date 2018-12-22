using System.ComponentModel.DataAnnotations;

namespace DFO.Assignment.Domain.Models.Users
{
    public class UserCreationModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(1, 150)]
        public int Age { get; set; }

        [StringLength(50)]
        public string Address { get; set; }
    }
}
