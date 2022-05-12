#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace MVC.Models
{
    public class PokojViewModel
    {
        public enum RodzajPokoju
        {
            standard,
            exclusive,
            apartament
        }
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public Hostel? Hostel { get; set; }
        public decimal CenaZaNocleg { get; set; }
        public int IloscLozek { get; set; }
        public RodzajPokoju Rodzaj { get; set; }
    }
}