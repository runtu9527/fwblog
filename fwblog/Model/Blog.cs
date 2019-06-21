using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fwblog.Model
{
    public class Blog
    {
        public string btitle { get; set; }
        public int bID { get; set; }
        public DateTime bCreatTime { get; set; } = DateTime.Now;
    }
}
