using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaV5.Core.QueryFilters
{
    public abstract class GlobalQueryFilter
    {
        public string Name { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
