using System.ComponentModel.DataAnnotations;

namespace Choam.ERP.Model
{
    public class ProjectForCreation
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public long Revenue { get; set; }
    }
}