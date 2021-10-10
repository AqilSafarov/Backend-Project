using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Trax.Models;

namespace Trax.Services
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<About> About { get; set; }
        public DbSet<Accordion> Accordion { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Consultation> Consultation { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Counters> Counters { get; set; }
        public DbSet<Expert> Expert { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<GalleryCategory> GalleryCategory { get; set; }
        public DbSet<HomeOne> HomeOne { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MobileApp> MobileApp { get; set; }
        public DbSet<MobileAppDetail> MobileAppDetail { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<PageDetail> PageDetail { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<ProcessType> ProcessType { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceCategory> ServiceCategory { get; set; }
        public DbSet<ServiceImage> ServiceImage { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Social> Social { get; set; }
        public DbSet<SocialToTeamMember> SocialToTeamMember { get; set; }
        public DbSet<Subscribe> Subscribe { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }
        public DbSet<Testimonial> Testimonial { get; set; }
        public DbSet<CustomUser> CustomUser { get; set; }

    }
}
