using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Announcement;

namespace WebApi.Services
{
    public interface IAnnouncementService
    {
        AnnouncementResponse GetById(int id);
        IEnumerable<AnnouncementResponse> GetAll();
        AnnouncementResponse Create(AnnouncementCreateRequest model, Account account);
        AnnouncementResponse Update(int id, AnnouncementUpdateRequest model);
        void Delete(int id);

        Announcement getAnnouncement(int id);
    }

    public class AnnouncementService : IAnnouncementService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AnnouncementService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public AnnouncementResponse GetById(int id)
        {
            var announcement = getAnnouncement(id);
            return _mapper.Map<AnnouncementResponse>(announcement);
        }

        public IEnumerable<AnnouncementResponse> GetAll()
        {
            var announcements = _context.Announcements;
            return _mapper.Map<IList<AnnouncementResponse>>(announcements);
        }

        public AnnouncementResponse Create(AnnouncementCreateRequest model, Account account)
        {
            // validate
            // PASS

            // map model to new account object
            var announcement = _mapper.Map<Announcement>(model);
            announcement.AccountId = account.Id;
            //announcement.Account = account;
            announcement.Created = DateTime.UtcNow;

            // save announcement
            _context.Announcements.Add(announcement);
            _context.SaveChanges();

            return _mapper.Map<AnnouncementResponse>(announcement);

        }

        public AnnouncementResponse Update(int id, AnnouncementUpdateRequest model)
        {
            var announcement = getAnnouncement(id);

            // validate
            // PASS

            // copy model to account and save
            _mapper.Map(model, announcement);
            announcement.Updated = DateTime.UtcNow;
            _context.Announcements.Update(announcement);
            _context.SaveChanges();

            return _mapper.Map<AnnouncementResponse>(announcement);
        }

        public void Delete(int id)
        {
            var announcement = getAnnouncement(id);
            _context.Announcements.Remove(announcement);
            _context.SaveChanges();
        }

        // helper methods

        public Announcement getAnnouncement(int id)
        {
            var announcement = _context.Announcements.Find(id);
            if (announcement == null) throw new KeyNotFoundException("Account not found");
            return announcement;
        }
    }
}
