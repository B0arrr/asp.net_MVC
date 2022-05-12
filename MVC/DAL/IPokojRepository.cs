using System;
using System.Collections.Generic;
using Models;

namespace MVC.DAL
{
    public interface IPokojRepository : IDisposable
    {
        IEnumerable<Pokoj> GetPokoje();
        IEnumerable<Pokoj> GetPokojeWithHostels();
        Pokoj GetPokojById(int pokojId);
        void InsertPokoj(Pokoj pokoj);
        void DeletePokoj(int pokojId);
        void UpdatePokoj(Pokoj pokoj);
        void Save();
    }
}