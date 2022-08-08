using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public int CompanyId { get; set; }
        public  virtual Company Company { get; set; }
    }
}
