using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace MVC.DAL
{
    public class PokojRepository : IPokojRepository, IDisposable
    {
        private readonly HostelContext _context;

        public PokojRepository(HostelContext context)
        {
            _context = context;
            _disposed = false;
        }

        public IEnumerable<Pokoj> GetPokoje()
        {
            return _context.Pokoje.ToList();
        }

        public IEnumerable<Pokoj> GetPokojeWithHostels()
        {
            return _context.Pokoje.Include(x => x.Hostel).ToList();
        }

        public Pokoj GetPokojById(int pokojId)
        {
            return _context.Pokoje
                .Include(h => h.Hostel)
                .FirstOrDefault(x => x.Id == pokojId);
        }

        public void InsertPokoj(Pokoj pokoj)
        {
            var hostelId = pokoj.Hostel.Id;
            pokoj.Hostel = _context.Hostels.FirstOrDefault(x => x.Id == hostelId);
            _context.Pokoje.Add(pokoj);
        }

        public void DeletePokoj(int pokojId)
        {
            var pokoj = _context.Pokoje.FirstOrDefault(x => x.Id == pokojId);
            if (pokoj != null) _context.Pokoje.Remove(pokoj);
        }

        public void UpdatePokoj(Pokoj pokoj)
        {
            _context.Entry(pokoj).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}