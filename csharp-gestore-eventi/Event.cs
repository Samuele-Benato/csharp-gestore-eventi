using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Event
    {
        private string _Title;
        public string Title
        {
            get => _Title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Il Titolo non può essere vuoto");
                }

                _Title = value;

            }
        }
        private DateTime _Date;
        public DateTime Date
        {
            get => _Date;
            set
            {
                if (_Date < DateTime.Today)
                {
                    throw new Exception("La data non è valida");
                }

                _Date = value;

            }
        }
        private int _EventCapacity;
        public int EventCapacity
            {
                get => _EventCapacity;
                set 
                {
                    if(_EventCapacity < 0)
                    {
                        throw new Exception("Il numero di posti deve essere positivo");
                    }

                    _EventCapacity = value;

                }
            }
        private int _ReservedSeats;
        public int ReservedSeats
        {
            get => _ReservedSeats;
            set => _ReservedSeats = value;
        }

        public Event (string title, DateTime date , int eventCapacity)
        {
            _Title = title;
            _Date = date;
            _EventCapacity = eventCapacity;
            _ReservedSeats = 0;
        }

        public int BookSeats(int seats)
        {
            if(Date < DateTime.Today)
            {
                throw new Exception("Evento già passato");
            }
            if(EventCapacity < 0)
            {
                throw new Exception("Posti non disponibili");
            }
            if(ReservedSeats + seats > EventCapacity)
            {
                throw new Exception("Posti non disponibili");
            }

            _EventCapacity -= seats;
            return _ReservedSeats += seats;
           
        }

        public int CancelSeats(int seats)
        {
            if(seats > ReservedSeats)
            {
                throw new Exception("Posti superiori ai posti prenotati");
            }
            if (Date < DateTime.Today)
            {
                throw new Exception("Evento già passato");
            }
            if (seats <= 0)
            {
                throw new ArgumentException("Il numero di posti da annullare deve essere maggiore di zero");
            }

            _EventCapacity += seats;
            return ReservedSeats -= seats;
        }

        public override string ToString() => $"{Date.ToString("dd/MM/yyyy")} - {Title}";
        
    }
}
