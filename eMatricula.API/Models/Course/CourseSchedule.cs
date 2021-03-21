using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eMatricula.API.Models
{
    public class CourseSchedule
    {
        [Key]
        public int Id { get; set; }

        public DayOfWeek Day { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }

        [JsonIgnore]
        public virtual Enrollment Enrollment { get; set; }
    }
}
