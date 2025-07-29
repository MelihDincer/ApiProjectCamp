using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ProductDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly PostgreApiContext _context;
        private readonly ApiContext _context;
        private readonly IValidator<Product> _validator;
        private readonly IMapper _mapper;

        public ProductsController(ApiContext context, IValidator<Product> validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _context.Products.ToList();
            return Ok(_mapper.Map<List<ResultProductDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var validationResult = _validator.Validate(_mapper.Map<Product>(createProductDto));
            if (validationResult.IsValid)
            {
                _context.Products.Add(_mapper.Map<Product>(createProductDto));
                _context.SaveChanges();
                return Ok("Yeni ürün eklendi.");
            }
            else
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı.");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.Find(id);
            var dtoValue = _mapper.Map<Product>(value);
            return Ok(dtoValue);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var validationResult = _validator.Validate(_mapper.Map<Product>(updateProductDto));
            if (validationResult.IsValid)
            {
                _context.Products.Update(_mapper.Map<Product>(updateProductDto));
                _context.SaveChanges();
                return Ok("Ürün bilgisi güncellendi.");
            }
            else
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(values));
        }
    }
}
