using Hotel_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Data_Access_Layer
{
    public class RoomDbContext : DbContext
    {
        public RoomDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
    }
}
