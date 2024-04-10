using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.RestaurantTable;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTableController : ControllerBase
    {
        private readonly IRestaurantTableService _service;
        private readonly IMapper _mapper;

        public RestaurantTableController(IRestaurantTableService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _service.GetAll();
            return Ok(_mapper.Map<List<ResultRestaurantTableDto>>(values));
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            var allRestaurantTables = _service.Count();
            var availableRestaurantTables = _service.Count(order => order.Status);
            var occupiedRestaurantTables = _service.Count(order => !order.Status);

            RestaurantTableCountDto restaurantTableCountDto = new RestaurantTableCountDto
            {
                All = allRestaurantTables,
                Available = availableRestaurantTables,
                Occupied = occupiedRestaurantTables
            };
            
            return Ok(restaurantTableCountDto);
        }
    }
}
