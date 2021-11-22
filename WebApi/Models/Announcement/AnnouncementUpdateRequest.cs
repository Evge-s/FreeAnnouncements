using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Announcement
{
    public class AnnouncementUpdateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
