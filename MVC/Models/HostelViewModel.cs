using System.Collections.Generic;

namespace MVC.Models
{
    public class HostelViewModel
    {
        public List<HostelItemViewModel> Hostels { get; set; }
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
    }
}