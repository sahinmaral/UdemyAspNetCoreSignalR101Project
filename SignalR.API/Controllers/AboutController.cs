using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.About;
using SignalR.Entity.Concrete;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _service;
        private readonly IMapper _mapper;

        public AboutController(IAboutService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _service.GetAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(values));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.GetById(id);
            return Ok(_mapper.Map<ResultAboutDto>(value));
        }
        
        [HttpPost]
        public IActionResult Create(CreateAboutDto entity)
        {
            var mappedEntity = _mapper.Map<About>(entity);
            _service.Add(mappedEntity);
            return Ok("Hakkında başarılı bir şekilde eklendi");
        }
        
        [HttpPut]
        public IActionResult Update(UpdateAboutDto entity)
        {
            var mappedEntity = _mapper.Map<About>(entity);
            _service.Update(mappedEntity);
            return Ok("Hakkında başarılı bir şekilde güncellendi");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _service.GetById(id);
            if (value is null)
                return NotFound("Aranan hakkında bulunamadı");
            
            _service.Delete(value);
            return Ok("Hakkında başarılı bir şekilde silindi");
        }
    }
}
