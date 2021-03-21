using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eMatricula.API.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Cycle { get; set; }

        [Required]
        public string Grade { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ClassAddress { get; set; }

        [Required]
        public int NumGroup { get; set; }

        [Required]
        public int MaxCap { get; set; }

        [Required]
        public int ActCap { get; set; }
 
        [JsonIgnore]
        public virtual Student Student { get; set; }
                
        public virtual Course Course { get; set; }

        public virtual ICollection<CourseSchedule> CourseSchedules { get; set; }

        [JsonIgnore]
        public virtual Professor Professor { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
