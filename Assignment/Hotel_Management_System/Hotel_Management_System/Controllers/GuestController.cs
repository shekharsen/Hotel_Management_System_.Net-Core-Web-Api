using Hotel_Management_System.Data_Access_Layer;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers
{
    [ApiController]
    [Route("api/guest")]
    public class GuestController : Controller
    {
        private readonly GuestDbContext Guest;

        public GuestController(GuestDbContext Guest)
        {
            this.Guest = Guest;
        }
        [HttpGet]
        public IActionResult GetGuestDetails()
        {
            return Ok(Guest.guests.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetGuestDetail([FromRoute] Guid id)
        {
            var roomid = Guest.guests.Find(id);

            if (roomid == null)
            {
                return NotFound();
            }
            return Ok(roomid);
        }

        [HttpPost]
        public IActionResult AddGuest(AddGuest addGuest)
        {
            var Guestt = new Guest()
            {
                guestId = Guid.NewGuid(),
                guest_address = addGuest.guest_address,
                guest_adhaar_card = addGuest.guest_adhaar_card,
                guest_age = addGuest.guest_age,
                guest_name = addGuest.guest_name,
                guest_email = addGuest.guest_email,
                guest_number = addGuest.guest_number
            };

            Guest.guests.Add(Guestt);
            Guest.SaveChanges();

            return Ok(Guestt);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateGuest([FromRoute] Guid id, UpdateGuest updateGuest)
        {
            var guestid = Guest.guests.Find(id);

            if (guestid != null)
            {
                guestid.guest_address = updateGuest.guest_address;
                guestid.guest_adhaar_card = updateGuest.guest_adhaar_card;
                guestid.guest_age = updateGuest.guest_age;
                guestid.guest_email = updateGuest.guest_email;
                guestid.guest_number = updateGuest.guest_number;
                guestid.guest_name = updateGuest.guest_name;

                Guest.SaveChanges();

                return Ok(guestid);
            }
            return NotFound();
        }

    }
}
