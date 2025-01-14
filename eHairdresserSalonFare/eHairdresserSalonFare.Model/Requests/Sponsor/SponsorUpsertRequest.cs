﻿namespace eHairdresserSalonFare.Model.Requests.Sponsor
{
    public class SponsorUpsertRequest
    {
        public string SponsorName { get; set; }
        public string About { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }
        public int HairdresserSalonId { get; set; }
    }
}
