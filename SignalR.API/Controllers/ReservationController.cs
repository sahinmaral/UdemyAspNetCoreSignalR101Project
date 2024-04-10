using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.Reservation;
using SignalR.Entity.Concrete;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _service.GetAll();
            return Ok(_mapper.Map<List<ResultReservationDto>>(values));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _service.GetById(id);
            return Ok(_mapper.Map<ResultReservationDto>(values));
        }
        
        [HttpPost]
        public IActionResult Create(CreateReservationDto entity)
        {
            var mappedEntity = _mapper.Map<Reservation>(entity);
            _service.Add(mappedEntity);
            return Ok("Reservasyon başarılı bir şekilde eklendi");
        }
        
        [HttpPut]
        public IActionResult Update(UpdateReservationDto entity)
        {
            var mappedEntity = _mapper.Map<Reservation>(entity);
            _service.Update(mappedEntity);
            return Ok("Reservasyon başarılı bir şekilde güncellendi");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _service.GetById(id);
            if (value is null)
                return NotFound("Aranan reservasyon bulunamadı");
            
            _service.Delete(value);
            return Ok("Reservasyon başarılı bir şekilde silindi");
        }
    }
}
