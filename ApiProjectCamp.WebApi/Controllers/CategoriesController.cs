using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.CategoryDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<Category> _validator;

        public CategoriesController(ApiContext context, IMapper mapper, IValidator<Category> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_context.Categories.ToList());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var validationResult = _validator.Validate(_mapper.Map<Category>(createCategoryDto));
            if (validationResult.IsValid)
            {
                _context.Categories.Add(_mapper.Map<Category>(createCategoryDto));
                _context.SaveChanges();
                return Ok("Kategori eklendi.");
            }
            return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori silindi.");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _mapper.Map<Category>(_context.Categories.Find(id));
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var validationResult = _validator.Validate(_mapper.Map<Category>(updateCategoryDto));
            if (validationResult.IsValid)
            {
                _context.Categories.Update(_mapper.Map<Category>(updateCategoryDto));
                _context.SaveChanges();
                return Ok("Kategori güncellendi.");
            }
            return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
        }
    }
}
