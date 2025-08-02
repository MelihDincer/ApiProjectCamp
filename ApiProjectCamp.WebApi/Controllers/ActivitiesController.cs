using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ActivitiesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ActivityList()
        {
            var values = _context.Activities.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return Ok("Etkinlik eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteActivity(int id)
        {
            var value = _context.Activities.Find(id);
            _context.Activities.Remove(value);
            _context.SaveChanges();
            return Ok("Etkinlik silindi.");
        }

        [HttpGet("GetActivity")]
        public IActionResult GetActivity(int id)
        {
            var value = _context.Activities.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateActivity(Activity activity)
        {
            _context.Activities.Update(activity);
            _context.SaveChanges();
            return Ok("Etkinlik güncellendi.");
        }
    }
}
