using System;
using System.Collections.Generic;

namespace PruebaV5.Core.Entities
{
    public partial class Province : BaseEntity
    {
        public long CountyId { get; set; }
        public string Name { get; set; }
        public string Abbrevation { get; set; }

        public virtual Country County { get; set; }
    }
}
