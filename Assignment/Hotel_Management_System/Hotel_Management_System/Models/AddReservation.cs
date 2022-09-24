namespace Hotel_Management_System.Models
{
    public class AddReservation
    {
        public DateTime checkin_time { get; set; }
        public DateTime checkout_time { get; set; }
        public int number_of_guests { get; set; }
        public Guid guestsId { get; set; }
    }
}
