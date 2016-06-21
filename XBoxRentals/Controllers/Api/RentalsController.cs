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
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<RentalDto> GetRentals(string query = null)
        {
            var rentalsQuery = _context.Rentals
                .Include(c => c.Customer)
                .Include(g => g.Game)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);

            return rentalsQuery;
        }

        [HttpGet]
        public IHttpActionResult GetGame(int id)
        {
            var rental = _context.Rentals
                .Include(c => c.Customer)
                .Include(g => g.Game)
                .SingleOrDefault(g => g.Id == id);

            if (rental == null)
                return NotFound();

            return Ok(Mapper.Map<Rental, RentalDto>(rental));
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var games = _context.Games.Where(g => newRental.GameIds.Contains(g.Id)).ToList();

            foreach (var game in games)
            {
                if (game.NumberAvailable == 0)
                    return BadRequest("Rental is unavailable.");

                game.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customer,
                    Game = game,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateRentalDateReturned(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rentalInDb = _context.Rentals
                .Include(c => c.Customer)
                .Include(g => g.Game)
                .SingleOrDefault(g => g.Id == id);

            var gameInDb = _context.Games
                .SingleOrDefault(g => g.Name == rentalInDb.Game.Name);

            if (rentalInDb == null || gameInDb == null)
                return NotFound();

            gameInDb.NumberAvailable++;
            rentalInDb.DateReturned = DateTime.Now; 

            _context.SaveChanges();

            return Ok();
        }

    }
}