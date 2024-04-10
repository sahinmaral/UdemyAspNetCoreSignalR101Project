using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.Basket;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("GetAllByRestaurantTableId/{id}")]
        public IActionResult GetAllByRestaurantTableId(int id)
        {
            var baskets = _basketService.GetAllByRestaurantTableId(id);
            return Ok(_mapper.Map<List<ResultBasketDto>>(baskets));
        }
    }
}
