using Encamina.workshop.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Encamina.workshop.Backend
{
    public class ConferenceContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

        public ConferenceContext(DbContextOptions<ConferenceContext> options) : base(options)
        {

        }
    }
}
