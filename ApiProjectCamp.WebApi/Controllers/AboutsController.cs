using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.AboutDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public AboutsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _mapper.Map<List<ResultAboutDto>>(_context.Abouts.ToList());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            _context.Abouts.Add(_mapper.Map<About>(createAboutDto));
            _context.SaveChanges();
            return Ok("Hakkımda alanı ekleme işlemi başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return Ok("Hakkımda alanı silme işlemi başarılı.");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            _context.Abouts.Update(value);
            _context.SaveChanges();
            return Ok("Hakkımda alanı güncelleme işlemi başarılı.");
        }
    }
}
