using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.Advertisement;

namespace SignalR.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertisementController : ControllerBase
{
    private readonly IAdvertisementService _advertisementService;
    private readonly IMapper _mapper;

    public AdvertisementController(IAdvertisementService advertisementService, IMapper mapper)
    {
        _advertisementService = advertisementService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_mapper.Map<ResultAdvertisementDto>(_advertisementService.GetAll().First()));
    }
}