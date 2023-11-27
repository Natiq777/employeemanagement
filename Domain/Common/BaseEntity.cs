using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain.Common
{
    public abstract class BaseEntity<T>
    {
        [Key]
        [Column("id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required T Id { get; set; }
        [Column("create_date")]
        public DateTime CreateDate { get; set; } 
    }
}
