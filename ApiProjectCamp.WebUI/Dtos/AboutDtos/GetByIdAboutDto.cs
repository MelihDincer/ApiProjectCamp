namespace ApiProjectCamp.WebUI.Dtos.AboutDtos
{
    public class GetByIdAboutDto
    {
        public int AboutId { get; set; }
        public string AboutTitle { get; set; }
        public string AboutImageUrl { get; set; }
        public string AboutVideoCoverImageUrl { get; set; }
        public string AboutVideoUrl { get; set; }
        public string AboutDescription { get; set; }
        public string AboutReservationNumber { get; set; }
    }
}
