using Hotel_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using static Hotel_Management_System.Models.RoomReservation;

namespace Hotel_Management_System.Data_Access_Layer
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
        {
        }

        public DbSet<RoomReservation> roomReservations { get; set; }
    }
}
