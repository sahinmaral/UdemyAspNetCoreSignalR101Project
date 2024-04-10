using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.SocialMediaAccount;
using SignalR.Entity.Concrete;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaAccountController : ControllerBase
    {
        private readonly ISocialMediaAccountService _service;
        private readonly IMapper _mapper;

        public SocialMediaAccountController(ISocialMediaAccountService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _service.GetAll();
            return Ok(_mapper.Map<List<ResultSocialMediaAccountDto>>(values));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.GetById(id);
            return Ok(_mapper.Map<ResultSocialMediaAccountDto>(value));
        }
        
        [HttpPost]
        public IActionResult Create(CreateSocialMediaAccountDto entity)
        {
            var mappedEntity = _mapper.Map<SocialMediaAccount>(entity);
            _service.Add(mappedEntity);
            return Ok("Sosyal medya hesabı başarılı bir şekilde eklendi");
        }
        
        [HttpPut]
        public IActionResult Update(UpdateSocialMediaAccountDto entity)
        {
            var mappedEntity = _mapper.Map<SocialMediaAccount>(entity);
            _service.Update(mappedEntity);
            return Ok("Sosyal medya hesabı başarılı bir şekilde güncellendi");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _service.GetById(id);
            if (value is null)
                return NotFound("Aranan sosyal medya hesabı bulunamadı");
            
            _service.Delete(value);
            return Ok("Sosyal medya hesabı başarılı bir şekilde silindi");
        }
    }
}
