using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.Contact;
using SignalR.Entity.Concrete;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;
        private readonly IMapper _mapper;

        public ContactController(IContactService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _service.GetAll();
            return Ok(_mapper.Map<List<ResultContactDto>>(values));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.GetById(id);
            return Ok(_mapper.Map<ResultContactDto>(value));
        }
        
        [HttpPost]
        public IActionResult Create(CreateContactDto entity)
        {
            var mappedEntity = _mapper.Map<Contact>(entity);
            _service.Add(mappedEntity);
            return Ok("İletişim başarılı bir şekilde eklendi");
        }
        
        [HttpPut]
        public IActionResult Update(UpdateContactDto entity)
        {
            var mappedEntity = _mapper.Map<Contact>(entity);
            _service.Update(mappedEntity);
            return Ok("İletişim başarılı bir şekilde güncellendi");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _service.GetById(id);
            if (value is null)
                return NotFound("Aranan iletişim bulunamadı");
            
            _service.Delete(value);
            return Ok("İletişim başarılı bir şekilde silindi");
        }
    }
}
