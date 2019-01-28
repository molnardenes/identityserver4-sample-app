using System;
using System.ComponentModel.DataAnnotations;

namespace Choam.ERP.API.Entities
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public long Revenue { get; set; }

        [Required]
        [MaxLength(50)]
        public string OwnerId { get; set; }
    }
}