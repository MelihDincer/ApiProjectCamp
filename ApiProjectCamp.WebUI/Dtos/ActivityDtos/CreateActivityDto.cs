namespace ApiProjectCamp.WebUI.Dtos.ActivityDtos
{
    public class CreateActivityDto
    {
        public string ActivityTitle { get; set; }
        public string ActivityDescription { get; set; }
        public string ActivityImageUrl { get; set; }
        public bool ActivityStatus { get; set; }
        public decimal ActivityPrice { get; set; }
    }
}
