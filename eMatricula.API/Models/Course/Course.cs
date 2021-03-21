using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eMatricula.API.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; }

        [Required]
        public string CourseIdentifier { get; set; }

        [Required]
        public int Credits { get; set; }      

        public ICollection<Requirement> Requirements { get; set; }

        [JsonIgnore]
        public virtual Career Career { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
