using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Models.Announcement;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementsController : BaseController
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementsController(
            IAnnouncementService accountService,
            IMapper mapper)
        {
            _announcementService = accountService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnnouncementResponse>> GetAll()
        {
            var announcement = _announcementService.GetAll();
            return Ok(announcement);
        }

        [HttpGet("{id:int}")]
        public ActionResult<AnnouncementResponse> GetById(int id)
        {
            return Ok(_announcementService.GetById(id));
        }

        [Authorize]
        [HttpPost]
        public ActionResult<AnnouncementResponse> Create(AnnouncementCreateRequest model)
        {
            var announcement = _announcementService.Create(model, Account);
            return Ok(announcement);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<AnnouncementResponse> Update(int id, AnnouncementUpdateRequest model)
        {
            var announcement = _announcementService.Update(id, model);
            return Ok(announcement);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            // checking if a user has an announcement by id
            if (!Account.Id.Equals(_announcementService.getAnnouncement(id).AccountId))
                return Unauthorized(new { message = "Invalid announcement" });

            _announcementService.Delete(id);
            return Ok(new { message = "Announcement deleted successfully" });
        }

    }
}
