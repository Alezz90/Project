using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Model
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Person_Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public int phoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string role { get; set; }
        public List<Appointment>? Appointment { get; set; }
    }
}
