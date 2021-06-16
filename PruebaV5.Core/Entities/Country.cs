using System;
using System.Collections.Generic;

namespace PruebaV5.Core.Entities
{
    public partial class Country : BaseEntity
    {
        public Country()
        {
            Province = new HashSet<Province>();
        }
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string Code { get; set; }
        public string Iso { get; set; }
        public bool Independent { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Province> Province { get; set; }
    }
}
