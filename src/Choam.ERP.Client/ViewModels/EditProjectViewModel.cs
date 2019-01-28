using System;
using System.ComponentModel.DataAnnotations;

namespace Choam.ERP.Client.ViewModels
{
    public class EditProjectViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public long Revenue { get; set; }

        [Required]
        public Guid Id { get; set; }
    }
}