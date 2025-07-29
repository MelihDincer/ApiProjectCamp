namespace ApiProjectCamp.WebApi.Dtos.ServiceDtos
{
    public class GetByIdServiceDto
    {
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceIconUrl { get; set; }
    }
}
