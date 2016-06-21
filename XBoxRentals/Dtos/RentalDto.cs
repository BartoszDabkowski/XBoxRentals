using System;

namespace XBoxRentals.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public GameDto Game { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}