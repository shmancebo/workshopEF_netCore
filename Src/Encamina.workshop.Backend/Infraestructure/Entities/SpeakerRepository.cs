using Encamina.workshop.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encamina.workshop.Backend.Infraestructure.Entities
{
    public class SpeakerRepository
    {
        private ConferenceContext context;

        public SpeakerRepository(ConferenceContext dbcontext)
        {
            context = dbcontext;
        }

        public List<Speaker> Get()
        {
            if (context.Speakers.Any())
            {
                return context.Speakers.ToList();
            }
            return null;
        }

        public Speaker Get(int Id)
        {
            if (context.Speakers.Any())
            {
                return context.Speakers.Where(e => e.ID == Id).Include(s => s.Sessions).FirstOrDefault();
            }
            return null;
        }

        public int Insert(Speaker Event)
        {
            context.Speakers.Add(Event);
            var result = context.SaveChanges();
            return Event.ID;
        }

        public void Update(Speaker Event)
        {
            context.Speakers.Update(Event);
            context.SaveChanges();
        }
    }
}
