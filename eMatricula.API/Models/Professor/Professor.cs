using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eMatricula.API.Models
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
        
        [JsonIgnore]
        public ICollection<ProfessorCounselor> Counselours { get; set; }

        [JsonIgnore]
        public ICollection<Enrollment> Enrollments { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
