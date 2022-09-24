using Hotel_Management_System.Data_Access_Layer;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RoomController : Controller
    {
        private readonly RoomDbContext dbContext;

        public RoomController(RoomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAllRoom()
        {
            return Ok(dbContext.Rooms.ToList());
        }


        [HttpGet]
        [Route("{roomid:guid}")]
        public IActionResult GetSingleRoom([FromRoute] Guid roomid)
        {
            var room2 = dbContext.Rooms.Find(roomid);

            if (room2 != null)
            { 
                return Ok(room2); 
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult AddRoom(AddRoom addRoom)
        {
            var room = new Room()
            {
                roomId = Guid.NewGuid(),
                room_status = addRoom.room_status,
                room_comment = addRoom.room_comment,
                room_inventory = addRoom.room_inventory,
                room_price = addRoom.room_price
            };

            dbContext.Rooms.Add(room);
            dbContext.SaveChanges();

            return Ok(room);
        }


        [HttpPut]
        [Route("{roomid:guid}")]
        public IActionResult UpdateRoom([FromRoute] Guid roomid, UpdateRoom updateRoom)
        {
            var room1 = dbContext.Rooms.Find(roomid);
            if (room1 != null)
            {
                room1.room_comment = updateRoom.room_comment;
                room1.room_inventory = updateRoom.room_inventory;
                room1.room_price = updateRoom.room_price;

                dbContext.SaveChanges();

                return Ok(room1);
            }

            return NotFound();
        }


        [HttpDelete]
        [Route("{roomid:guid}")]
        public IActionResult DeleteRoom([FromRoute] Guid roomid)
        {
            var room3 = dbContext.Rooms.Find(roomid);
            if (room3 != null)
            {
                dbContext.Rooms.Remove(room3);
                dbContext.SaveChanges();
                return Ok(room3);
            }
            return NotFound();
        }
    }
}
