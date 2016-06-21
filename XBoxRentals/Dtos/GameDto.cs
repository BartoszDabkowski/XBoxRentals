using System;

namespace XBoxRentals.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GenreDto Genre { get; set; }
        public int GenreId { get; set; }
        public RatingDto Rating { get; set; }
        public int RatingId { get; set; }
        public FileDto Image { get; set; }
        public int ImageId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Summary { get; set; }
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }
    }
}