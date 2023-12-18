using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Model
{
    public class Specialization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpeciaID { get; set; }
        public string Specia_Name { get; set; }
        public List<Appointment> Appointment { get; private set; }
    }
}
