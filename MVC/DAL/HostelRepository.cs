using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace MVC.DAL
{
    public class HostelRepository : IHostelRepository, IDisposable
    {
        private readonly HostelContext _context;

        public HostelRepository(HostelContext context)
        {
            _context = context;
            _disposed = false;
        }

        public IEnumerable<Hostel> GetHostels()
        {
            return _context.Hostels.ToList();
        }

        public Hostel GetHostelById(int hostelId)
        {
            return _context.Hostels.FirstOrDefault(x => x.Id == hostelId);
        }

        public void InsertHostel(Hostel hostel)
        {
            _context.Hostels.Add(hostel);
        }

        public void DeleteHostel(int hostelId)
        {
            var hostel = _context.Hostels.FirstOrDefault(x => x.Id == hostelId);
            if (hostel != null) _context.Hostels.Remove(hostel);
        }

        public void UpdateHostel(Hostel hostel)
        {
            _context.Entry(hostel).State = EntityState.Modified;
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