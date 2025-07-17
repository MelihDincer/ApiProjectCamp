namespace ApiProjectCamp.WebApi.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public string MessageNameSurname { get; set; }
        public string MessageEmail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
