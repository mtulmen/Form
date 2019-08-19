using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entities
{
    public class UserEntity : EntityBase
    {
        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public decimal Credit { get; set; }

        
    }
}
