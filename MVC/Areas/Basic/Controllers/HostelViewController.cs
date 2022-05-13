using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC.DAL;
using MVC.Models;

namespace MVC.Areas.Basic.Controllers;

[Area("Basic")]
public class HostelViewController : Controller
{
    private readonly IHostelRepository _hostelRepository;
    private readonly IMapper _mapper;

    public HostelViewController(IMapper mapper, IHostelRepository hostelRepository)
    {
        _mapper = mapper;
        _hostelRepository = hostelRepository;
    }

    public async Task<IActionResult> Index()
    {
        var vm = _hostelRepository.GetHostels().ToList();
        var mapper = _mapper.Map<List<HostelViewModel>>(vm);
        return View(mapper);
    }
}