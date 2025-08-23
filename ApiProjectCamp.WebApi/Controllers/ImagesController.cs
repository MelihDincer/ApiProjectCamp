using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ImageDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ImagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ImageList()
        {
            var values = _mapper.Map<List<ResultImageDto>>(_context.Images.ToList());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateImage(CreateImageDto createImageDto)
        {
            _context.Images.Add(_mapper.Map<Image>(createImageDto));
            _context.SaveChanges();
            return Ok("Görsel eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteImage(int id)
        {
            var value = _context.Images.Find(id);
            _context.Images.Remove(value);
            _context.SaveChanges();
            return Ok("Görsel silindi.");
        }

        [HttpGet("GetImage")]
        public IActionResult GetImage(int id)
        {
            var value = _mapper.Map<Image>(_context.Images.Find(id));
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateImage(UpdateImageDto updateImageDto)
        {
            _context.Images.Update(_mapper.Map<Image>(updateImageDto));
            _context.SaveChanges();
            return Ok("Görsel güncellendi.");
        }
    }
}
