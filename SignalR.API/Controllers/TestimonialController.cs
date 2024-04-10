using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.Testimonial;
using SignalR.Entity.Concrete;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _service;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _service.GetAll();
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(values));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.GetById(id);
            return Ok(_mapper.Map<ResultTestimonialDto>(value));
        }
        
        [HttpPost]
        public IActionResult Create(CreateTestimonialDto entity)
        {
            var mappedEntity = _mapper.Map<Testimonial>(entity);
            _service.Add(mappedEntity);
            return Ok("Referans başarılı bir şekilde eklendi");
        }
        
        [HttpPut]
        public IActionResult Update(UpdateTestimonialDto entity)
        {
            var mappedEntity = _mapper.Map<Testimonial>(entity);
            _service.Update(mappedEntity);
            return Ok("Referans başarılı bir şekilde güncellendi");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _service.GetById(id);
            if (value is null)
                return NotFound("Aranan referans bulunamadı");
            
            _service.Delete(value);
            return Ok("Referans başarılı bir şekilde silindi");
        }
    }
}
