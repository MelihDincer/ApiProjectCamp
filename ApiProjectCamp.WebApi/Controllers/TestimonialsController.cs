using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.TestimonialDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        private readonly IValidator<Testimonial> _validator;

        public TestimonialsController(IMapper mapper, ApiContext context, IValidator<Testimonial> validator)
        {
            _mapper = mapper;
            _context = context;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _context.Testimonials.ToList();
            var dtoValues = _mapper.Map<List<Testimonial>>(values);
            return Ok(dtoValues);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var validationResult = _validator.Validate(_mapper.Map<Testimonial>(createTestimonialDto));
            if (validationResult.IsValid)
            {
                _context.Testimonials.Add(_mapper.Map<Testimonial>(createTestimonialDto));
                _context.SaveChanges();
                return Ok("Yeni referans eklendi.");
            }
            else
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            var dtoValue = _mapper.Map<Testimonial>(value);
            return Ok(dtoValue);
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Referans silindi.");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var validationResult = _validator.Validate(_mapper.Map<Testimonial>(updateTestimonialDto));
            if (validationResult.IsValid)
            {
                _context.Testimonials.Update(_mapper.Map<Testimonial>(updateTestimonialDto));
                _context.SaveChanges();
                return Ok("Referans bilgileri güncellendi");
            }
            else
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
        }
    }
}
