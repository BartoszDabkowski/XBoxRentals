using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using XBoxRentals.ViewModels;

namespace XBoxRentals.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public File Image { get; set; }

        [Required]
        public int ImageId { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        public Rating Rating { get; set; }

        [Required]
        public int RatingId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:MMM DD YYYY}")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        [Range(1,100)]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        public Game(GameFormViewModel gameFormViewModel)
        {
            if (gameFormViewModel.Id != null)
                Id = (int)gameFormViewModel.Id;
            Name = gameFormViewModel.Name;
            ImageId = gameFormViewModel.ImageId;
            GenreId = gameFormViewModel.GenreId;
            RatingId = gameFormViewModel.RatingId;
            ReleaseDate = gameFormViewModel.ReleaseDate;
            Summary = gameFormViewModel.Summary;
            NumberInStock = gameFormViewModel.NumberInStock;
        }

        public Game()
        {
            
        }
    }

    
}