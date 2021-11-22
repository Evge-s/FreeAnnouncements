using System;

namespace WebApi.Models.Announcement
{
    public class AnnouncementResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int? AccountId { get; set; }
    }
}
