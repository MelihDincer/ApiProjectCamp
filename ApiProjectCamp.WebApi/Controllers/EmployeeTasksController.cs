using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.EmployeeTaskDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTasksController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public EmployeeTasksController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult EmployeeTaskList()
        {
            var values = _context.EmployeeTasks.ToList();
            return Ok(_mapper.Map<List<ResultEmployeeTaskDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateEmployeeTask(CreateEmployeeTaskDto createEmployeeTaskDto)
        {
            _context.EmployeeTasks.Add(_mapper.Map<EmployeeTask>(createEmployeeTaskDto));
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteEmployeeTask(int id)
        {
            var value = _context.EmployeeTasks.Find(id);
            _context.EmployeeTasks.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı.");
        }

        [HttpGet("GetEmployeeTask")]
        public IActionResult GetEmployeeTask(int id)
        {
            var value = _context.EmployeeTasks.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateEmployeeTask(UpdateEmployeeTaskDto updateEmployeeTaskDto)
        {
            var value = _mapper.Map<EmployeeTask>(updateEmployeeTaskDto);
            _context.EmployeeTasks.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı.");
        }
    }
}
