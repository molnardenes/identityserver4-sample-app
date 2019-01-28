using System.ComponentModel.DataAnnotations;

namespace Choam.ERP.Model
{
    public class ProjectForUpdate
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}