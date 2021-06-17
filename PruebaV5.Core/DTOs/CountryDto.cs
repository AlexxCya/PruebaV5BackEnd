using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaV5.Core.DTOs
{
    public class CountryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string Code { get; set; }
        public string Iso { get; set; }
        public bool Independent { get; set; }
        public string ImageUrl { get; set; }
    }
}
