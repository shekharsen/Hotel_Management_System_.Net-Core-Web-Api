﻿namespace Hotel_Management_System.Models
{
    public class Room
    {
        public Guid roomId { get; set; }

        public bool room_status { get; set; }

        public string room_comment { get; set; }

        public string room_inventory { get; set; }

        public double room_price { get; set; }

    }
}