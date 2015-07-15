using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stash.SDK.Domain
{
    public class Project
    {
        public String Key { get; set; }
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Boolean Public { get; set; }
        public String Type { get; set; }
        public Boolean IsPersonal { get; set; }
    }
}
