using PruebaV5.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaV5.Core.DTOs
{
    public class SecurityDto
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public RoleType? Role { get; set; }
    }
}
