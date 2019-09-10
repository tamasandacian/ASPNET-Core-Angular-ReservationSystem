using System;

namespace webapi.Models.ViewModels
{
    public class ReservationVM
    {
        // Id = Reservation Id
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public double Total { get; set; }

        public string Field { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string ImageURL { get; set; }
        public string Address { get; set; }
        public string StartProgram { get; set; }
        public string EndProgram { get; set; }

    }
}