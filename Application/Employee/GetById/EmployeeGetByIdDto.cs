using Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.GetById
{
    public class EmployeeGetByIdDto:EmployeeDto
    {
        public string Department { get; set; }
    }
}
