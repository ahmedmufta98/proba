﻿namespace eHairdresserSalonFare.Model.DTO
{
    public class RatingHairdresserDto
    {
        public int HairdresserId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
    }
}
