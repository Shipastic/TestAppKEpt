using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Logic.MappingDTO
{
    public class UpdateCompanyDTO
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("List Users")]
        public virtual ICollection<UserDTO>? Users { get; set; }
    }
}
