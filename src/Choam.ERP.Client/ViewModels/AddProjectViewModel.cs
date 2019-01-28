using System.ComponentModel.DataAnnotations;

namespace Choam.ERP.Client.ViewModels
{
    public class AddProjectViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public long Revenue { get; set; }
    }
}