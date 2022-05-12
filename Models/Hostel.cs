using System.Collections.Generic;

namespace Models
{
    public class Hostel
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        private ICollection<Pokoj> _pokoje;
    }
}