namespace ApiProjectCamp.WebUI.Dtos.ChefDtos
{
    public class GetByIdChefDto
    {
        public int ChefId { get; set; }
        public string ChefNameSurname { get; set; }
        public string ChefTitle { get; set; }
        public string ChefDescription { get; set; }
        public string ChefImageUrl { get; set; }
    }
}
