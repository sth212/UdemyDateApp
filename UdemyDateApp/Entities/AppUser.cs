using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyDateApp.Entities
{
    public class AppUser
    {
       public int Id { set; get; }
        public required string Name { set; get; }
        public required byte[] PassHash { get;  set; }
        public required byte[] PassSalt { get;  set; }
    }
}
