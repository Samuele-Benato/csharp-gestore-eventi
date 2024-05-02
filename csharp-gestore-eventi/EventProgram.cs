using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class EventProgram
    {
        public string Title { get; set; }
        public List<Event> Events { get; set; } 

        public EventProgram(string title)
        {
            Title = title;
            Events = new List<Event>();
        }

        public void AddEvent(Event e)
        {
            Events.Add(e);
        }

        public List<Event> EventsInDate(DateTime date)
        {
            List<Event> eventsInDate = new List<Event>();

            foreach (var ev in Events)
            {
                if (ev.Date == date)
                {
                    eventsInDate.Add(ev);
                }
            }

            return eventsInDate;
        }

        public static string PrintEvents(List<Event> events)
        {
            string result = "Lista degli eventi:\n";

            foreach (var ev in events)
            {
                result += $"{ev}\n";
            }

            return result;
        }

        public int GetEventsCount()
        {
            int count = Events.Count;
            return count;
        }

        public void DeleteAllEvents() => Events.Clear();

        public string GetEvents(List<Event> events)
        {
            string result = "Lista degli eventi attuali:\n";

            foreach (var ev in events)
            {
                result += ev.ToString() + "\n";
            }

            return result;
        }
    }
}
