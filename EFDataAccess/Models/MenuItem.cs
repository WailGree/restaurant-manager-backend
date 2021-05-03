using System.ComponentModel.DataAnnotations;

namespace EFDataAccess.Models
{
    public class MenuItem
    {
        [Key] [MaxLength(10)] public string Id { get; set; }
        [Required] [MaxLength(200)] public string Name { get; set; }
        [MaxLength(300)] public string Picture { get; set; }
    }
}