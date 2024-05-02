namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Event> events = new List<Event>();
          
            Console.WriteLine("1. Inserisci Titolo evento");
            string title = Console.ReadLine();

            Console.WriteLine("2. Inserisci Data evento (formato YYYY-MM-DD)");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date) || date < DateTime.Today)
            {
                Console.WriteLine("Data non valida o già passata. Riprova.");
                Console.WriteLine("2. Inserisci Data evento (formato YYYY-MM-DD)");
            }

            Console.WriteLine("3. Inserisci Capienza evento");
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
        }
    }
}
