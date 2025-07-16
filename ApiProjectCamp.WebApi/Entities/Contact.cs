namespace ApiProjectCamp.WebApi.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactMapLocation { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactOpenHours { get; set; }
    }
}
