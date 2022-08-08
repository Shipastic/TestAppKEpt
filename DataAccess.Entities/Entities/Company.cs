using DataAccess.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Entities
{
    public class Company
    {
        //public Company()
        //{
        //    Users = new HashSet<User>();
        //}
        public int Id { get; set; } 
        public string CompanyName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
