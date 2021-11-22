using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Announcement
{
    public class AnnouncementCreateRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
