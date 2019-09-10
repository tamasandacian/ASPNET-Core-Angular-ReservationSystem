using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService) {
            _calendarService = calendarService;
        }

        [HttpGet("[action]/{fieldId}")]
        public IActionResult GetReservations(int fieldId)
        {
            try
            {
               var reservations = _calendarService.GetReservationsByFieldId(fieldId);
               return Ok(reservations);
            }
            catch(ApplicationException ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult CreateReservation([FromBody] Reservation reservation)
        {
            try
            {
                _calendarService.CreateReservation(reservation);
                return Ok();
            }
            catch(ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetReservationById(int id) {
            try
            {
                var reservations = _calendarService.GetReservationById(id);
                return Ok(reservations);
            } 
            catch(ApplicationException ex) 
            {
                return BadRequest(ex.Message);    
            }
        }

        [HttpGet("[action]/{title}")]
        public IActionResult SearchReservations(string title) {
            try
            {
                var reservations = _calendarService.SearchReservations(title);
                return Ok(reservations);
            } 
            catch(ApplicationException ex) 
            {
                return BadRequest(ex.Message);    
            }
        }
    }
}