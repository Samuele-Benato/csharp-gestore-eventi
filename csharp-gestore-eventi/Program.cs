using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Event> events = new List<Event>();
            EventProgram list = null;

            bool running = true;
            while (running)
            {
                Console.WriteLine("Premi 1 per inserire un evento");
                Console.WriteLine("Premi 2 per inserire un programma di eventi");
                Console.WriteLine("Premi 3 per ricercare un evento dalla sua data");
                Console.WriteLine("Premi 0 per uscire");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Inserisci Titolo evento");
                        string title = Console.ReadLine();

                        Console.WriteLine("Inserisci Data evento (formato YYYY-MM-DD)");
                        DateTime date;
                        while (!DateTime.TryParse(Console.ReadLine(), out date) || date < DateTime.Today)
                        {
                            Console.WriteLine("Data non valida o già passata. Riprova.");
                            Console.WriteLine("Inserisci Data evento (formato YYYY-MM-DD)");
                        }

                        Console.WriteLine("Inserisci Capienza evento");
                        int eventCapacity = int.Parse(Console.ReadLine());

                        Event newEvent = new Event(title, date, eventCapacity);
                        events.Add(newEvent);
                        Console.WriteLine($"Evento aggiunto con successo!");

                        Console.WriteLine("Vuoi prenotare posti? (y/n)");
                        string input = Console.ReadLine();

                        while (input == "y")
                        {
                            int remainingSeats = newEvent.EventCapacity - newEvent.ReservedSeats;
                            Console.WriteLine($"Posti rimanenti : {remainingSeats}");
                            Console.WriteLine("Quanti posti vuoi prenotare?");

                            int seats = int.Parse(Console.ReadLine());
                            newEvent.BookSeats(seats);
                            Console.WriteLine($"Prenotato! posti rimanenti : {newEvent.EventCapacity}");

                            Console.WriteLine("Vuoi prenotare altri posti? (y/n)");
                            input = Console.ReadLine();
                        }

                        Console.WriteLine("Vuoi disdire posti? (y/n)");
                        string input2 = Console.ReadLine();

                        while (input2 == "y")
                        {
                            Console.WriteLine($"Posti riservati : {newEvent.ReservedSeats}, Quanti posti vuoi disdire?");

                            int seats2 = int.Parse(Console.ReadLine());
                            newEvent.CancelSeats(seats2);

                            Console.WriteLine($"Fatto! posti rimanenti : {newEvent.EventCapacity}");
                            Console.WriteLine("Vuoi disdire altri posti? (y/n)");
                            input2 = Console.ReadLine();
                        }
                        break;

                    case "2":
                        Console.WriteLine("Qual è il titolo del programma di eventi?");
                        string programTitle = Console.ReadLine();
                        list = new EventProgram(programTitle);

                        Console.WriteLine("Quanti eventi vuoi aggiungere?");
                        int count = int.Parse(Console.ReadLine());

                        for (int i = 1; i <= count; i++)
                        {
                            Console.WriteLine($"{i}° Evento : Inserisci Titolo evento");
                            string title2 = Console.ReadLine();

                            Console.WriteLine("Inserisci Data evento (formato YYYY-MM-DD)");
                            while (!DateTime.TryParse(Console.ReadLine(), out date) || date < DateTime.Today)
                            {
                                Console.WriteLine("Data non valida o già passata. Riprova.");
                                Console.WriteLine("Inserisci Data evento (formato YYYY-MM-DD)");
                            }

                            Console.WriteLine("Inserisci Capienza evento");
                            eventCapacity = int.Parse(Console.ReadLine());

                            Event newEvent2 = new Event(title2, date, eventCapacity);
                            list.AddEvent(newEvent2);
                        }
                        Console.WriteLine($"Nome programma : {programTitle}\n {list.ToString()}");
                        break;

                    case "3":
                        Console.WriteLine($"Scrivi una data (formato YYYY-MM-DD)");
                        DateTime selectedDate;
                        while (!DateTime.TryParse(Console.ReadLine(), out selectedDate) || selectedDate < DateTime.Today)
                        {
                            Console.WriteLine("Data non valida o già passata. Riprova.");
                            Console.WriteLine("Scrivi una data (formato YYYY-MM-DD)");
                        }

                        List<Event> eventsInDate = list.EventsInDate(selectedDate);

                        if (eventsInDate.Count <= 0)
                            throw new NullReferenceException("Non ci sono elementi presenti nella lista");

                        Console.WriteLine(EventProgram.PrintEvents(eventsInDate));

                        if (eventsInDate.Count > 0)
                        {
                            Console.WriteLine("Vuoi eliminare tutti gli eventi? (y/n)");
                            string input3 = Console.ReadLine();

                            if (input3 == "y")
                            {
                                list.DeleteAllEvents();
                                Console.WriteLine("Lista svuotata con successo!");
                            }
                        }
                        
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }
            }
        }
    }
}
