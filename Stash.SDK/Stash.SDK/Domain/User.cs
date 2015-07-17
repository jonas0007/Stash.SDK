using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stash.SDK.Domain
{
    public class User
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public String EmailAddress { get; set; }
        public String DisplayName { get; set; }
        public Boolean Active { get; set; }
        public String Slug { get; set; }
        public String Type { get; set; }
    }
}
