using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.DiscountOfDay;
using SignalR.Entity.Concrete;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountOfDayController : ControllerBase
    {
        private readonly IDiscountOfDayService _service;
        private readonly IMapper _mapper;

        public DiscountOfDayController(IDiscountOfDayService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _service.GetAll();
            return Ok(_mapper.Map<List<ResultDiscountOfDayDto>>(values));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.GetById(id);
            return Ok(_mapper.Map<ResultDiscountOfDayDto>(value));
        }
        
        [HttpPost]
        public IActionResult Create(CreateDiscountOfDayDto entity)
        {
            var mappedEntity = _mapper.Map<DiscountOfDay>(entity);
            _service.Add(mappedEntity);
            return Ok("Günün indirimi başarılı bir şekilde eklendi");
        }
        
        [HttpPost("UpdateStatus/{id}")]
        public IActionResult UpdateStatus(int id)
        {
            _service.UpdateStatus(id);
            return Ok("Günün indirimi başarılı bir şekilde güncellendi");
        }
        
        [HttpPut]
        public IActionResult Update(UpdateDiscountOfDayDto entity)
        {
            var mappedEntity = _mapper.Map<DiscountOfDay>(entity);
            _service.Update(mappedEntity);
            return Ok("Günün indirimi başarılı bir şekilde güncellendi");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _service.GetById(id);
            if (value is null)
                return NotFound("Aranan günün indirimi bulunamadı");
            
            _service.Delete(value);
            return Ok("Günün indirimi başarılı bir şekilde silindi");
        }
    }
}
