using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaV5.Core.QueryFilters
{
    public class CountryQueryFilter
    {
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
