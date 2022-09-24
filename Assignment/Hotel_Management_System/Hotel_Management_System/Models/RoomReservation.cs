using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class RoomReservation
    {
            [Key]
            public Guid reservationId { get; set; }
            public Guid RoomId { get; set; }
            [ForeignKey("RoomId")]

            public DateTime checkin_time { get; set; }
            public DateTime checkout_time { get; set; }
            public int number_of_guests { get; set; }
            public Guid guestsId { get; set; }
            [ForeignKey("GuestId")]

            public virtual Room room { get; set; }
            public virtual Guest guest { get; set; }
        
    }
}
