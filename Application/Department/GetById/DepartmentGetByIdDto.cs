using Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Department.GetById
{
    public class DepartmentGetByIdDto :DepartmentDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
