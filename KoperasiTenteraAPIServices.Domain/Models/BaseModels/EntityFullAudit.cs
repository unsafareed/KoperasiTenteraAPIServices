using KoperasiTenteraAPIServices.Shared.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraAPIServices.Domain.Models.BaseModels
{
    public class EntityFullAudit
    {
        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(AuditConstants.UserAuditMaxLenght)]
        public string CreatedBy { get; set; } = default!;

        public DateTime? LastModifiedAt { get; set; }

        [MaxLength(AuditConstants.UserAuditMaxLenght)]
        public string? LastModifiedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        [MaxLength(AuditConstants.UserAuditMaxLenght)]
        public string? DeletedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
