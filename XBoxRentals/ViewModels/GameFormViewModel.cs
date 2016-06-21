using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using XBoxRentals.Models;
using XBoxRentals.Models.Validation;

namespace XBoxRentals.ViewModels
{
    public class GameFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:MMM DD YYYY}")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        [Required]
        public int GenreId { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        [Required]
        public int RatingId { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }

        [Required]
        public int  ImageId { get; set; }
        public File Image { get; set; }

        [Display(Name = "Upload Image")]
        [ImageSubmited]
        public HttpPostedFileBase File { get; set; }

        public string Title => Id != 0 ? "Edit Game" : "New Game";

        public GameFormViewModel()
        {
            Id = 0;
        }

        public GameFormViewModel(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            ReleaseDate = game.ReleaseDate.Date;
            Summary = game.Summary;
            NumberInStock = game.NumberInStock;
            GenreId = game.GenreId;
            RatingId = game.RatingId;
            ImageId = game.ImageId;
            Image = game.Image;
        }
    }
}