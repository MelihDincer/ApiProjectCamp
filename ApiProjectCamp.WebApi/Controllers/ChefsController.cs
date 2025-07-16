using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ChefDtos;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        ApiContext _context;

        public ChefsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _context.Chefs.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateChef(CreateChefDto createChefDto)
        {
            Chef chef = new Chef();
            chef.ChefTitle = createChefDto.ChefTitle;
            chef.ChefNameSurname = createChefDto.ChefNameSurname;
            chef.ChefDescription = createChefDto.ChefDescription;
            chef.ChefImageUrl = createChefDto.ChefImageUrl;
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Yeni şef bilgisi eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var value = _context.Chefs.Find(id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Şef bilgisi silindi");
        }

        [HttpGet("GetChef")]
        public IActionResult GetChef(int id)
        {
            var value = _context.Chefs.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateChef(UpdateChefDto updateChefDto)
        {
            Chef chef = new Chef();
            chef.ChefId = updateChefDto.ChefId;
            chef.ChefTitle = updateChefDto.ChefTitle;
            chef.ChefNameSurname = updateChefDto.ChefNameSurname;
            chef.ChefDescription = updateChefDto.ChefDescription;
            chef.ChefImageUrl = updateChefDto.ChefImageUrl;
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Chef bilgisi güncellendi.");
        }
    }
}
