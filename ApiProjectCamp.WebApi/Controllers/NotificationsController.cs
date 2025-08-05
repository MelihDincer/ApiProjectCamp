using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.NotificationDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IValidator<Notification> _validator;
        private readonly ApiContext _context;

        public NotificationsController(IMapper mapper, IValidator<Notification> validator, ApiContext context)
        {
            _mapper = mapper;
            _validator = validator;
            _context = context;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _context.Notifications.ToList();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var validationResult = _validator.Validate(_mapper.Map<Notification>(createNotificationDto));
            if (validationResult.IsValid)
            {
                _context.Notifications.Add(_mapper.Map<Notification>(createNotificationDto));
                _context.SaveChanges();
                return Ok("Yeni bildirim eklendi.");
            }
            else
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
        }

        [HttpGet("GetNotification")]
        public IActionResult GetNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            return Ok(_mapper.Map<GetByIdNotificationDto>(value));
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            _context.Notifications.Remove(value);
            _context.SaveChanges();
            return Ok("Bildirim silindi.");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var validationResult = _validator.Validate(_mapper.Map<Notification>(updateNotificationDto));
            if (validationResult.IsValid)
            {
                _context.Notifications.Update(_mapper.Map<Notification>(updateNotificationDto));
                _context.SaveChanges();
                return Ok("Bildirim güncellendi.");
            }
            else
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
        }
    }
}
