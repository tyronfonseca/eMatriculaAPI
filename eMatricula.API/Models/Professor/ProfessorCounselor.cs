using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eMatricula.API.Models
{
    public class ProfessorCounselor
    {
        public int Id { get; set; }

        public string TimeTable { get; set; }

        public string Office { get; set; }

        public string Telephone { get; set; }
       
        public virtual Professor Professor { get; set; }

        [JsonIgnore]
        public virtual Student Student { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
