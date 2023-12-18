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
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointentID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime appoinDate { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        public DateTime appoinTime { get; set; }
        public string? status { get; set; }

        [ForeignKey("person_ID")]
        public int person_ID { get; set; }
        [ForeignKey("specialization")]
        public int specialization_ID { get; set; }
        public Person person { get; set; }
        public Specialization specialization { get; set; }
    
}
}
