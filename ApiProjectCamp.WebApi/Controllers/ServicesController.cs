using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ServiceDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        private readonly IValidator<Service> _validator;

        public ServicesController(IMapper mapper, ApiContext context, IValidator<Service> validator)
        {
            _mapper = mapper;
            _context = context;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Services.ToList();
            var dtoValues = _mapper.Map<List<Service>>(values);
            return Ok(dtoValues);
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDto createServiceDto)
        {
            var validationResult = _validator.Validate(_mapper.Map<Service>(createServiceDto));
            if (validationResult.IsValid)
            {
                _context.Services.Add(_mapper.Map<Service>(createServiceDto));
                _context.SaveChanges();
                return Ok("Yeni hizmet eklendi.");
            }
            else
            {
                return BadRequest(validationResult.Errors.Select(x=>x.ErrorMessage));
            }
        }

        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var value = _context.Services.Find(id);
            var dtoValue = _mapper.Map<Service>(value);
            return Ok(dtoValue);
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Hizmet silindi.");
        }

        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
        {
            var validationResult = _validator.Validate(_mapper.Map<Service>(updateServiceDto));
            if (validationResult.IsValid)
            {
                _context.Services.Update(_mapper.Map<Service>(updateServiceDto));
                _context.SaveChanges();
                return Ok("Hizmet bilgileri güncellendi");
            }
            else
            {
                return BadRequest(validationResult.Errors.Select(x=>x.ErrorMessage));
            }
        }
    }
}
