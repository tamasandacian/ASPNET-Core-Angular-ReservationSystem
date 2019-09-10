using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("Field")]
    public class Field
    {
        [Key]
        public int FieldId { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public double PriceHour { get; set; }
        public string PathURL { get; set; }

        public virtual FieldDetail Detail { get; set; }        
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}