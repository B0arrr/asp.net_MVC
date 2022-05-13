using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC.DAL;
using MVC.Models;

namespace MVC.Areas.Basic.Controllers;

[Area("Basic")]
public class PokojViewController : Controller
{
    private readonly IPokojRepository _pokojRepository;
    private readonly IMapper _mapper;

    public PokojViewController(IMapper mapper, IPokojRepository pokojRepository)
    {
        _mapper = mapper;
        _pokojRepository = pokojRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        return View(_pokojRepository.GetPokojeWithHostels());
    }
}