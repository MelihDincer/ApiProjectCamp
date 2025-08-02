namespace ApiProjectCamp.WebApi.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityTitle { get; set; }
        public string ActivityDescription { get; set; }
        public string ActivityImageUrl { get; set; }
        public bool ActivityStatus { get; set; }
        public decimal ActivityPrice { get; set; }
    }
}
