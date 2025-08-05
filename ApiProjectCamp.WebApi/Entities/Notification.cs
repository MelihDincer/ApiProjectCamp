namespace ApiProjectCamp.WebApi.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string NotificationDescription { get; set; }
        public string NotificationIconUrl { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool NotificationIsRead { get; set; }
    }
}
