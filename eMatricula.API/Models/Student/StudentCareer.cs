using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eMatricula.API.Models
{
    public class StudentCareer
    {
        [Key]
        public int Id { get; set; }

        public bool IsMain { get; set; }

        [JsonIgnore]
        public virtual Student Student { get; set; }

        [JsonIgnore]
        public virtual Career Career { get; set; }
    }
}
