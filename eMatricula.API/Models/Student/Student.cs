using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eMatricula.API.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string Scholarship { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string Debt { get; set; }

        [Required]
        [Column(TypeName = "varchar(6)")]
        public string UniId { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string PersonalId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string UniEmail { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string PersonalEmail { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Province { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Canton { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Distric { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255)]
        public string ExactAddress { get; set; }
        
        [Required]
        public bool IsActive { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public ICollection<Career> Careers {get; set;}

        [JsonIgnore]
        public ICollection<Enrollment> Enrollments { get; set; }
        
        public ICollection<ProfessorCounselor> Counselors { get; set; }
    }
}
