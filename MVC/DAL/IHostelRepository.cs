using System;
using System.Collections.Generic;
using Models;

namespace MVC.DAL
{
    public interface IHostelRepository : IDisposable
    {
        IEnumerable<Hostel> GetHostels();
        Hostel GetHostelById(int hostelId);
        void InsertHostel(Hostel hostel);
        void DeleteHostel(int hostelId);
        void UpdateHostel(Hostel hostel);
        void Save();
    }
}