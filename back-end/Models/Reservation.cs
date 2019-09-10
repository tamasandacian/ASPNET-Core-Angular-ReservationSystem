using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        //Id = Reservation Id
        public int? Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public int FieldId { get; set; }
        public double Total { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public int CustomerId { get; set; }
        
        public virtual Payment Payment { get; set; }
        public virtual Field Field { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}