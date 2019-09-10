using System;

namespace webapi.Models.ViewModels
{
    public class FieldVM
    {
        public int FieldId { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string PathURL { get; set; }
        public double PriceHour { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string StartProgram { get; set; }
        public string EndProgram { get; set; }
    }
}