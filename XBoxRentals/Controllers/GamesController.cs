using System.Linq;
using System.Web.Mvc;
using XBoxRentals.Models;
using XBoxRentals.Utility;
using XBoxRentals.ViewModels;

namespace XBoxRentals.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (User.IsInRole("CanManageGames"))
                return View("List");
            
            return View("ReadOnlyList");
        }                             

        public ActionResult Details(int id)
        {
            var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);

            if(gameInDb == null)
                return HttpNotFound();

            gameInDb.Image = _context.Images.SingleOrDefault(g => g.Id == gameInDb.ImageId);
            gameInDb.Genre = _context.Genres.SingleOrDefault(g => g.Id == gameInDb.GenreId);
            gameInDb.Rating = _context.Ratings.SingleOrDefault(g => g.Id == gameInDb.RatingId);

            return View(gameInDb);
        }

        [Authorize(Roles="CanManageGames")]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var ratings = _context.Ratings.ToList();
            var newGameViewModel = new GameFormViewModel()
            {
                Genres = genres,
                Ratings = ratings
            };

            return View("GameForm", newGameViewModel);
        }

        [Authorize(Roles = "CanManageGames")]
        public ActionResult Edit(int id)
        {
            var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);

            if (gameInDb == null)
                return HttpNotFound();

            var newGameViewModel = new GameFormViewModel(gameInDb)
            {
                Genres = _context.Genres.ToList(),
                Ratings = _context.Ratings.ToList(),
                Image = _context.Images.Single(i => i.Id == gameInDb.ImageId)
            };

            return View("GameForm", newGameViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(GameFormViewModel gameFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                gameFormViewModel.Genres = _context.Genres.ToList();
                gameFormViewModel.Ratings = _context.Ratings.ToList();
                gameFormViewModel.Image = _context.Images.SingleOrDefault(i => i.Id == gameFormViewModel.ImageId);
                return View("GameForm", gameFormViewModel);
            }

            var fileUploadService = new FileUploadService(_context);
            var file = fileUploadService.ConvertHttpPostedFileBaseToFile(gameFormViewModel.File);

            var game = new Game(gameFormViewModel);

            if (gameFormViewModel.Id == 0)
            {
                _context.Images.Add(file);
                _context.SaveChanges();

                game.ImageId = file.Id;
                game.NumberAvailable = game.NumberInStock;
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.Single(g => g.Id == game.Id);
                gameInDb.Name = game.Name;
                gameInDb.GenreId = game.GenreId;
                gameInDb.RatingId = game.RatingId;
                gameInDb.ReleaseDate = game.ReleaseDate.Date;
                gameInDb.Summary = game.Summary;
                gameInDb.NumberInStock = game.NumberInStock;

                if (file != null)
                {
                    var imageInDb = _context.Images.Single(i => i.Id == gameInDb.ImageId);

                    imageInDb.Bytes = file.Bytes;
                    imageInDb.ContentType = file.ContentType;
                }
            }

                _context.SaveChanges();

                return RedirectToAction("List", "Games");
            }
    }
}







//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Save(Game gameFormViewModel)
//{
//    var fileUploadService = new FileUploadService(_context);
//    var fileId = 0;

//    if (!ModelState.IsValid || (fileId = fileUploadService.ConvertHttpPostedFileBaseToFile(file)) == 0)
//    {
//        var genres = _context.Genres.ToList();
//        var ratings = _context.Ratings.ToList();
//        var newGameViewModel = new GameFormViewModel()
//        {
//            Genres = genres,
//            Ratings = ratings
//        };

//        return View("GameForm", newGameViewModel);
//    }

//    gameFormViewModel.ImageId = fileId;

//    if (gameFormViewModel.Id == 0)
//        _context.Games.Add(gameFormViewModel);
//    else
//    {
//        var gameInDb = _context.Games.Single(g => g.Id == gameFormViewModel.Id);
//        gameInDb.Name = gameFormViewModel.Name;
//        gameInDb.GenreId = gameFormViewModel.GenreId;
//        gameInDb.RatingId = gameFormViewModel.RatingId;
//        gameInDb.ReleaseDate = gameFormViewModel.ReleaseDate.Date;
//        gameInDb.Summary = gameFormViewModel.Summary;
//        gameInDb.NumberInStock = gameFormViewModel.NumberInStock;
//        gameInDb.ImageId = gameFormViewModel.ImageId;
//    }

//    _context.SaveChanges();

//    return RedirectToAction("Index", "Games");
//}
//    }