using System;

namespace Models
{
    public class Wypozyczenie
    {
        public int Id { get; set; }
        public DateTime DataUtworzeznia { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }
        public StatusWypozyczenia Status { get; set; }
        public Klient Klient{ get; set; }
        public Pokoj Pokoj { get; set; }
    }   
}