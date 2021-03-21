using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eMatricula.API.Models
{
    public class Requirement
    {
        [Key]
        public int Id { get; set; }

        public bool IsRequirement { get; set; }
                
        [JsonIgnore]
        public virtual Course Course { get; set; }

        public virtual Course CourseReq { get; set; }
    }
}
