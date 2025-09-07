using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ReservationDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<Reservation> _validator;

        public ReservationsController(ApiContext context, IMapper mapper, IValidator<Reservation> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult ReservationList()
        {
            var values = _mapper.Map<List<ResultReservationDto>>(_context.Reservations.ToList());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateReservation(CreateReservationDto createReservationDto)
        {
            var validationResult = _validator.Validate(_mapper.Map<Reservation>(createReservationDto));
            if (validationResult.IsValid)
            {
                _context.Reservations.Add(_mapper.Map<Reservation>(createReservationDto));
                _context.SaveChanges();
                return Ok("Rezervasyon eklendi.");
            }
            return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
        }

        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            var value = _context.Reservations.Find(id);
            _context.Reservations.Remove(value);
            _context.SaveChanges();
            return Ok("Rezervasyon silindi.");
        }

        [HttpGet("GetReservation")]
        public IActionResult GetReservation(int id)
        {
            var value = _mapper.Map<Reservation>(_context.Reservations.Find(id));
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            var validationResult = _validator.Validate(_mapper.Map<Reservation>(updateReservationDto));
            if (validationResult.IsValid)
            {
                _context.Reservations.Update(_mapper.Map<Reservation>(updateReservationDto));
                _context.SaveChanges();
                return Ok("Rezervasyon güncellendi.");
            }
            return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
        }

        [HttpGet("GetTotalReservastionCount")]
        public IActionResult GetTotalReservationCount()
        {
            var value = _context.Reservations.Count();
            return Ok(value);
        }

        [HttpGet("GetTotalCustomerCount")]
        public IActionResult GetTotalCustomerCount()
        {
            var value = _context.Reservations.Sum(x => x.ReservationCountOfPeople);
            return Ok(value);
        }

        [HttpGet("GetPendingReservations")]
        public IActionResult GetPendingReservations()
        {
            var value = _context.Reservations.Where(x=>x.ReservationStatus == "Rezervasyon Onayı Bekleniyor").Count();
            return Ok(value);
        }

        [HttpGet("GetApprovedReservations")]
        public IActionResult GetApprovedReservations()
        {
            var value = _context.Reservations.Where(x => x.ReservationStatus == "Rezervasyon Onaylandı").Count();
            return Ok(value);
        }
    }
}
