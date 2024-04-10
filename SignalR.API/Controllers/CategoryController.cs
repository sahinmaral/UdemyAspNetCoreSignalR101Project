using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.Category;
using SignalR.Entity.Concrete;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _service.GetAll();
            return Ok(_mapper.Map<List<ResultCategoryDto>>(values));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.GetById(id);
            return Ok(_mapper.Map<ResultCategoryDto>(value));
        }
        
        [HttpPost]
        public IActionResult Create(CreateCategoryDto entity)
        {
            var mappedEntity = _mapper.Map<Category>(entity);
            _service.Add(mappedEntity);
            return Ok("Kategori başarılı bir şekilde eklendi");
        }
        
        [HttpPut]
        public IActionResult Update(UpdateCategoryDto entity)
        {
            var mappedEntity = _mapper.Map<Category>(entity);
            _service.Update(mappedEntity);
            return Ok("Kategori başarılı bir şekilde güncellendi");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _service.GetById(id);
            if (value is null)
                return NotFound("Aranan kategori bulunamadı");
            
            _service.Delete(value);
            return Ok("Kategori başarılı bir şekilde silindi");
        }
    }
}
