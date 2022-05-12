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
    public class PokojController : Controller
    {
        private readonly IPokojRepository _pokojRepository;
        private readonly IHostelRepository _hostelRepository;
        private readonly IMapper _mapper;

        public PokojController(IMapper mapper, IPokojRepository pokojRepository, IHostelRepository hostelRepository)
        {
            _mapper = mapper;
            _pokojRepository = pokojRepository;
            _hostelRepository = hostelRepository;
        }

        // GET: Pokoj
        public async Task<IActionResult> Index()
        {
            return View(_pokojRepository.GetPokojeWithHostels());
        }

        // GET: Pokoj/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokoj = _pokojRepository.GetPokojById(id);
            if (pokoj == null)
            {
                return NotFound();
            }

            var pokojMapper = _mapper.Map<Pokoj>(pokoj);

            return View(pokojMapper);
        }

        // GET: Pokoj/Create
        public IActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var hostel in _hostelRepository.GetHostels())
            {
                items.Add(new SelectListItem { Text = hostel.Nazwa, Value = hostel.Id.ToString() });
            }

            ViewBag.Hostels = items;
            return View();
        }

        // POST: Pokoj/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Nazwa,Opis,Hostel,CenaZaNocleg,IloscLozek,Rodzaj")] PokojViewModel pokoj)
        {
            if (ModelState.IsValid)
            {
                var pokojMap = _mapper.Map<Pokoj>(pokoj);
                _pokojRepository.InsertPokoj(pokojMap);
                _pokojRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            
            return View(pokoj);
        }

        // GET: Pokoj/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokoj = _pokojRepository.GetPokojById(id);
            if (pokoj == null)
            {
                return NotFound();
            }

            var pokojMap = _mapper.Map<PokojViewModel>(pokoj);
            
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var hostel in _hostelRepository.GetHostels())
            {
                if (pokojMap.Hostel.Nazwa == hostel.Nazwa)
                {
                    items.Add(new SelectListItem { Text = hostel.Nazwa, Value = hostel.Id.ToString(), Selected = true});
                    continue;
                }
                items.Add(new SelectListItem { Text = hostel.Nazwa, Value = hostel.Id.ToString() });
            }

            ViewBag.Hostels = items;
            return View(pokojMap);
        }

        // POST: Pokoj/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Nazwa,Opis,Hostel,CenaZaNocleg,IloscLozek,Rodzaj")] PokojViewModel pokoj)
        {
            if (id != pokoj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    pokoj.Hostel = _hostelRepository.GetHostelById(pokoj.Hostel.Id);
                    var pokojMap = _mapper.Map<Pokoj>(pokoj);
                    _pokojRepository.UpdatePokoj(pokojMap);
                    _pokojRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokojExists(pokoj.Id))
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

            return View(pokoj);
        }

        // GET: Pokoj/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokoj = _pokojRepository.GetPokojById(id);
            if (pokoj == null)
            {
                return NotFound();
            }

            var pokojMap = _mapper.Map<PokojViewModel>(pokoj);

            return View(pokojMap);
        }

        // POST: Pokoj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokoj = _pokojRepository.GetPokojById(id);
            if (pokoj == null)
            {
                return NotFound();
            }

            _pokojRepository.DeletePokoj(id);
            _pokojRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PokojExists(int id)
        {
            return _pokojRepository.GetPokoje().Any(x => x.Id == id);
        }
    }
}