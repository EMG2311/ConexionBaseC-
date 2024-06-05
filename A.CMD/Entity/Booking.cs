using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.CMD.Entity
{
    internal class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {  get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReservatedDate { get; set; }
        [ForeignKey("DestinationId")]
        public Destination destination { get; set; }
        [ForeignKey("CustomerId")]
        public Customer customer { get; set; }
        public Booking() { }
    }
}
