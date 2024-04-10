using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.Product;
using SignalR.Entity.Concrete;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _service.GetAll();
            return Ok(_mapper.Map<List<ResultProductDto>>(values));
        }
        
        [HttpGet("CategoryDetail")]
        public IActionResult GetAllWithCategories()
        {
            var values = _service.GetAllWithCategories();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(values));
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _service.GetById(id);
            return Ok(_mapper.Map<ResultProductDto>(value));
        }
        
        [HttpPost]
        public IActionResult Create(CreateProductDto entity)
        {
            var mappedEntity = _mapper.Map<Product>(entity);
            _service.Add(mappedEntity);
            return Ok("Ürün başarılı bir şekilde eklendi");
        }
        
        [HttpPut]
        public IActionResult Update(UpdateProductDto entity)
        {
            var mappedEntity = _mapper.Map<Product>(entity);
            _service.Update(mappedEntity);
            return Ok("Ürün başarılı bir şekilde güncellendi");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _service.GetById(id);
            if (value is null)
                return NotFound("Aranan ürün bulunamadı");
            
            _service.Delete(value);
            return Ok("Ürün başarılı bir şekilde silindi");
        }
    }
}
