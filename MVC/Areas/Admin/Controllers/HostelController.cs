using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using MVC.DAL;
using MVC.Models;

namespace MVC.Controllers
{
    [Area("Admin")]
    public class HostelController : Controller
    {
        private readonly IHostelRepository _hostelRepository;
        private readonly IMapper _mapper;

        public HostelController(IHostelRepository hostelRepository, IMapper mapper)
        {
            _hostelRepository = hostelRepository;
            _mapper = mapper;
        }

        // GET: HostelContext
        public async Task<IActionResult> Index()
        {
            return View(_hostelRepository.GetHostels());
        }

        // GET: HostelContext/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostel = _hostelRepository.GetHostelById(id);
            if (hostel == null)
            {
                return NotFound();
            }

            var hostelMap = _mapper.Map<HostelItemViewModel>(hostel);

            return View(hostelMap);
        }

        // GET: HostelContext/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HostelContext/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis")] HostelItemViewModel hostelItemViewModel)
        {
            var hostelMap = _mapper.Map<Hostel>(hostelItemViewModel);
            if (ModelState.IsValid)
            {
                _hostelRepository.InsertHostel(hostelMap);
                _hostelRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(hostelItemViewModel);
        }

        // GET: HostelContext/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostel = _hostelRepository.GetHostelById(id);
            if (hostel == null)
            {
                return NotFound();
            }

            var hostelMap = _mapper.Map<HostelItemViewModel>(hostel);
            
            return View(hostelMap);
        }

        // POST: HostelContext/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Opis")] HostelItemViewModel hostelItemViewModel)
        {
            var hostel = _mapper.Map<Hostel>(hostelItemViewModel);
            if (id != hostel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _hostelRepository.UpdateHostel(hostel);
                    _hostelRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostelExists(hostel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hostelItemViewModel);
        }

        // GET: HostelContext/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostel = _hostelRepository.GetHostelById(id);
            if (hostel == null)
            {
                return NotFound();
            }

            var hostelMap = _mapper.Map<HostelItemViewModel>(hostel);

            return View(hostelMap);
        }

        // POST: HostelContext/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hostel = _hostelRepository.GetHostelById(id);
            if (hostel == null)
            {
                return NotFound();
            }
            _hostelRepository.DeleteHostel(id);
            _hostelRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool HostelExists(int id)
        {
            return _hostelRepository.GetHostels().Any(x => x.Id == id);
        }
    }
}
