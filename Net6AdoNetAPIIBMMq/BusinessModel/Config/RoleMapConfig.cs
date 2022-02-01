using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModel.Config
{
    public class RoleMapConfig : IRoleMapConfig
    {
        public Dictionary<string, string> Values { get; set; }
    }
}
