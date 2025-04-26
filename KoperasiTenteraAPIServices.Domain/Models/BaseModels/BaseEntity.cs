using NUlid;
using System.ComponentModel.DataAnnotations;

namespace KoperasiTenteraAPIServices.Domain.Models.BaseModels
{
    public abstract class BaseEntity : EntityFullAudit
    {
        [Key]
        [Required]
        public string Id { get; set; } = Ulid.NewUlid().ToString();

        [Timestamp]
        public byte[]? ConcurrencyToken { get; set; }
    }
}
