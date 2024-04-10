using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.Notification;
using SignalR.Entity.Concrete;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _service.GetAll();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.GetById(id);
            return Ok(_mapper.Map<ResultNotificationDto>(value));
        }
        
        [HttpPost]
        public IActionResult Create(CreateNotificationDto entity)
        {
            var mappedEntity = _mapper.Map<Notification>(entity);
            _service.Add(mappedEntity);
            return Ok("Bildirim başarılı bir şekilde eklendi");
        }
        
        [HttpPut]
        public IActionResult Update(UpdateNotificationDto entity)
        {
            var mappedEntity = _mapper.Map<Notification>(entity);
            _service.Update(mappedEntity);
            return Ok("Bildirim başarılı bir şekilde güncellendi");
        }
        
        [HttpPost("UpdateStatus/{id}")]
        public IActionResult UpdateStatus(int id)
        {
            _service.UpdateStatus(id);
            return Ok("Bildirim başarılı bir şekilde güncellendi");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _service.GetById(id);
            if (value is null)
                return NotFound("Aranan referans bulunamadı");
            
            _service.Delete(value);
            return Ok("Bildirim başarılı bir şekilde silindi");
        }
    }
}
