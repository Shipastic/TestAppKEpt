using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Logic.MappingDTO
{
    public class UserDTO
    {
        [JsonPropertyName("Company")]
        public virtual CompanyDTO Company { get; set; }

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("UserName")]
        public string UserName { get; set; }

        [JsonIgnore]
        public int CompanyId { get; set; }       
    }
}
