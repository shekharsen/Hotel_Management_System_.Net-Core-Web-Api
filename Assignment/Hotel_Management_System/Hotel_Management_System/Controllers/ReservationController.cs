using Hotel_Management_System.Data_Access_Layer;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers
{
    [ApiController]
    [Route("api/reservation")]
    public class ReservationController : Controller
    {
        private readonly ReservationDbContext reservation;

        public ReservationController(ReservationDbContext reservation)
        {
            this.reservation = reservation;
        }

        [HttpGet]
        public IActionResult GetReservationDetails()
        {
            return Ok(reservation.roomReservations.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRoomDetail([FromRoute] Guid id)
        {
            var roomid = reservation.roomReservations.Find(id);

            if (roomid == null)
            {
                return NotFound();
            }
            return Ok(roomid);
        }

        [HttpPost]
        public IActionResult AddReservation(AddReservation addReservation)
        {
            var Room_Reservation = new RoomReservation()
            {
                
            };

            reservation.roomReservations.Add(Room_Reservation);
            reservation.SaveChanges();

            return Ok(Room_Reservation);
        }
    }
}
