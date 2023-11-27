using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    [Table("departments")]
    public class Department: BaseEntity<int>
    { 
        [Column("name")]
        [MaxLength(100)]
        public required string Name { get; set; } 
        public ICollection<Employee> Employees { get; set; }
    }
}
