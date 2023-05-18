using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace ReminderHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderManager _reminderManager;

        public ReminderController(IReminderManager reminderManager)
        {
            _reminderManager = reminderManager;
        }

        [HttpGet("getall")]
        public List<Reminder> GetAll()
        {
            return _reminderManager.GetAllReminders();
        }

        [HttpPost("add")]
        public object AddReminder(AddReminderDTO addReminderDTO)
        {
            _reminderManager.AddReminder(addReminderDTO);
            return Ok("Reminder added.");
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateReminder(Reminder reminder, int id)
        {
            _reminderManager.UpdateReminder(reminder, id);
            return Ok(new { status = 200, message = reminder });
        }

        [HttpDelete("remove/{id}")]
        public IActionResult DeleteReminder(Reminder reminder, int id)
        {
            _reminderManager.RemoveReminder(reminder, id);
            return Ok("Reminder deleted.");
        }
        [HttpGet("getreminderbyid")]
        public object GetReminderById(int id)
        {
            return _reminderManager.GetReminderById(id);
        }
    }
}
