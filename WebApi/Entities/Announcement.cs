using System;

namespace WebApi.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int? AccountId { get; set; }
        public Account Account { get; set; }
    }
}
