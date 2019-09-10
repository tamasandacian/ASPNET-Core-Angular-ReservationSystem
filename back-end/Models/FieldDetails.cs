using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("FieldDetail")]
    public class FieldDetail
    {
        [Key]
        public int FieldId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string StartProgram { get; set; }
        public string EndProgram { get; set; }

        [ForeignKey("FieldId")]
        public virtual Field Field { get; set; }
    }
}