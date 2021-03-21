using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eMatricula.API.Models
{
    public class Career
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Campus { get; set; }        

        [JsonIgnore]
        public ICollection<Course> Courses { get; set; }
        [JsonIgnore]
        public ICollection<Student> Students { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
