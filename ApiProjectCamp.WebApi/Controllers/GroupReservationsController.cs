using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.GroupReservation;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupReservationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public GroupReservationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GroupReservationList()
        {
            var values = _mapper.Map<List<ResultGroupReservationDto>>(_context.GroupReservations.ToList());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateGroupReservation(CreateGroupReservationDto createGroupReservationDto)
        {
            _context.GroupReservations.Add(_mapper.Map<GroupReservation>(createGroupReservationDto));
            _context.SaveChanges();
            return Ok("Eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteGroupReservation(int id)
        {
            var value = _context.GroupReservations.Find(id);
            _context.GroupReservations.Remove(value);
            _context.SaveChanges();
            return Ok("Silindi.");
        }

        [HttpGet("GetGroupReservation")]
        public IActionResult GetGroupReservation(int id)
        {
            var value = _mapper.Map<GroupReservation>(_context.GroupReservations.Find(id));
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateGroupReservation(UpdateGroupReservationDto updateGroupReservationDto)
        {
            _context.GroupReservations.Update(_mapper.Map<GroupReservation>(updateGroupReservationDto));
            _context.SaveChanges();
            return Ok("Güncellendi.");
        }
    }
}
