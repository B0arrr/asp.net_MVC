#nullable enable
namespace Models
{
    public class Pokoj
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public Hostel? Hostel { get; set; }
        public decimal CenaZaNocleg { get; set; }
        public int IloscLozek { get; set; }
        public RodzajPokoju RodzajPokoju { get; set; }
    }
}