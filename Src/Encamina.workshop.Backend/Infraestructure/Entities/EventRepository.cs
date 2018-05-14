using Encamina.workshop.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encamina.workshop.Backend.Infraestructure.Entities
{
    public class EventRepository
    {
        private ConferenceContext context;

        public EventRepository(ConferenceContext dbcontext)
        {
            context = dbcontext;
        }
         
        public List<Event> Get()
        {
            if (context.Events.Any())
            {
                return context.Events.ToList();
            }
            return null;
        }

        public Event Get(int Id)
        {
            if (context.Events.Any())
            {
                var result = context.Events.Where(e => e.ID == Id).Include(s => s.Sessions).FirstOrDefault();
                return result;
            }
            return null;
        }

        public int Insert(Event Event)
        {
            context.Events.Add(Event);
            var result =context.SaveChanges();
            return Event.ID;
        }

        public void Update(Event Event)
        {
            context.Events.Update(Event);
            context.SaveChanges();
        }
    }
}
