using Application.Common.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public abstract class BaseHandler
    {
        protected readonly IEmployeeManagementDBContext Context;
     
        protected readonly IMapper Mapper;

        protected BaseHandler(IServiceProvider serviceProvider)
        {
            Context = (IEmployeeManagementDBContext)serviceProvider.GetService(typeof(IEmployeeManagementDBContext));            
            Mapper = (IMapper)serviceProvider.GetService(typeof(IMapper));
        }

        protected CancellationToken CancellationToken { get; set; }
    }
}
