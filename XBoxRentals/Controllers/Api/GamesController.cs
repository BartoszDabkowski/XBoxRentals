using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using XBoxRentals.Dtos;
using XBoxRentals.Models;

namespace XBoxRentals.Controllers.Api
{
    public class GamesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<GameDto> GetGames(string query = null)
        {
            var gamesQuery = _context.Games
                .Include(g => g.Genre)
                .Include(g => g.Rating)
                .Include(g => g.Image);

            if (!string.IsNullOrWhiteSpace(query))
                gamesQuery = gamesQuery
                    .Where(g => g.Name.Contains(query))
                    .Where(g => g.NumberAvailable > 0);

            return gamesQuery
                .ToList()
                .Select(Mapper.Map<Game, GameDto>);
        }

        [HttpGet]
        public IHttpActionResult GetGame(int id)
        {
            var game = _context.Games
                .Include(g => g.Genre)
                .Include(g => g.Rating)
                .Include(g => g.Image)
                .SingleOrDefault(g => g.Id == id);

            if (game == null)
                return NotFound();

            return Ok(Mapper.Map<Game, GameDto>(game));
        }

        [HttpPost]
        public IHttpActionResult CreateGame(GameDto gameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var game = Mapper.Map<GameDto, Game>(gameDto);

            _context.Games.Add(game);
            _context.SaveChanges();

            gameDto.Id = game.Id;
            return Created(new Uri(Request.RequestUri + "/" + game.Id), gameDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateGame(int id, GameDto gameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);

            if (gameInDb == null)
                return NotFound();

            Mapper.Map(gameDto, gameInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteGame(int id)
        {
            var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);
            
            if (gameInDb == null)
                return NotFound();

            var fileInDb = _context.Images.SingleOrDefault(i => i.Id == gameInDb.ImageId);

            _context.Games.Remove(gameInDb);
            _context.Images.Remove(fileInDb);

            _context.SaveChanges();

            return Ok();
        }
    }
}
