using CTF.Models;
using RST.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTF.Features.Models
{
    [Table(nameof(Policy))]
    public record Policy : IPolicy
    {
        [Key]
        public Guid? Id { get; set; }
        public Guid? ClientId { get; set; }
        [Required, ColumnDescriptor(System.Data.SqlDbType.NVarChar, 200)]
        public string? Name { get; set; }
        public bool HasPublicAccess { get; set; }
        public bool CanRead { get; set;}
        public bool CanWrite { get; set;}
        public bool CanDelete { get; set;}
    }
}
