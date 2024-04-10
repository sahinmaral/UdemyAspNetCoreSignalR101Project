using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.Highlight;
using SignalR.Entity.Concrete;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighlightController : ControllerBase
    {
        private readonly IHighlightService _service;
        private readonly IMapper _mapper;

        public HighlightController(IHighlightService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _service.GetAll();
            return Ok(_mapper.Map<List<ResultHighlightDto>>(values));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.GetById(id);
            return Ok(_mapper.Map<ResultHighlightDto>(value));
        }
        
        [HttpPost]
        public IActionResult Create(CreateHighlightDto entity)
        {
            var mappedEntity = _mapper.Map<Highlight>(entity);
            _service.Add(mappedEntity);
            return Ok("Öne çıkanlar başarılı bir şekilde eklendi");
        }
        
        [HttpPut]
        public IActionResult Update(UpdateHighlightDto entity)
        {
            var mappedEntity = _mapper.Map<Highlight>(entity);
            _service.Update(mappedEntity);
            return Ok("Öne çıkanlar başarılı bir şekilde güncellendi");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _service.GetById(id);
            if (value is null)
                return NotFound("Aranan öne çıkanlar bulunamadı");
            
            _service.Delete(value);
            return Ok("Öne çıkanlar başarılı bir şekilde silindi");
        }
    }
}
