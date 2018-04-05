using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LymcWeb.Data;
using LymcWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using System.Security.Claims;
using System.Dynamic;

namespace LymcWeb.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/Reservations")]
    [EnableCors("AllowAllOrigins")]
    public class ReservationsApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReservationsApi
        [HttpGet]
        public IEnumerable<Object> GetReservation()
        {
            List<Object> reservation = new List<Object>();
            foreach(Reservation r in _context.Reservation)
            {
                dynamic b = new ExpandoObject();
                b.createdBy = _context.Users.Find(r.CreatedBy).UserName;
                b.reservedBoat = _context.Boat.Find(r.ReservedBoat).BoatName; //r.Boat.BoatName
                b.id = r.Id;
                b.startDate = r.StartDate;
                b.endDate = r.EndDate;

                reservation.Add(b);
            }
            return reservation;
        }

        // GET: api/ReservationsApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservation = await _context.Reservation.SingleOrDefaultAsync(m => m.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/ReservationsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation([FromRoute] int id, [FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReservationsApi
        [HttpPost]
        public async Task<IActionResult> PostReservation([FromBody] Reservation reservation)
        {

            reservation.CreatedBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Reservation.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        }

        // DELETE: api/ReservationsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservation = await _context.Reservation.SingleOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservation.Remove(reservation);
            await _context.SaveChangesAsync();

            return Ok(reservation);
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.Id == id);
        }
    }
}