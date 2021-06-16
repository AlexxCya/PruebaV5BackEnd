using System;
using System.Collections.Generic;

namespace PruebaV5.Core.Entities
{
    public partial class Security:BaseEntity
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string Role { get; set; }
    }
}
