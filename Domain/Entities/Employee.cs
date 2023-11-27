using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("employees")]
    public class Employee: BaseEntity<int>
    { 
        [Column("name")]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Column("surname")]
        [MaxLength(100)]
        public required string Surname { get; set; }
        [Column("birth_date")]
        public required DateTime BirthDate { get; set; }
        [Column("departmend_id")]       
        public required int DepartmendId { get; set; }      
        [ForeignKey("DepartmendId")]
        public virtual Department Department { get; set; }
    }
}
