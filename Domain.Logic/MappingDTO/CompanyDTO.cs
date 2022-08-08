using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Domain.Logic.MappingDTO
{
    public class CompanyDTO
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string CompanyName { get; set; }

     // [JsonPropertyName("List Users")]
     // public virtual ICollection<UserDTO>? Users { get; set; }
    }
}
