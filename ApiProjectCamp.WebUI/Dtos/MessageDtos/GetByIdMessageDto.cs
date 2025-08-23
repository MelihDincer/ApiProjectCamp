namespace ApiProjectCamp.WebUI.Dtos.MessageDtos
{
    public class GetByIdMessageDto
    {
        public int MessageId { get; set; }
        public string MessageNameSurname { get; set; }
        public string MessageEmail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
