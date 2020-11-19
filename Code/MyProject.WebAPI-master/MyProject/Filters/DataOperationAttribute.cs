using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Filters
{
    public class DataOperationAttribute : Attribute, IFilterMetadata
    {
        public bool Transaction { get; set; }
    }
}
