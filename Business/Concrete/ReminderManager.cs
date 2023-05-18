using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ReminderManager : IReminderManager
    {
        private readonly IReminderDal _reminderDal;
        public ReminderManager(IReminderDal reminderDal)
        {
            _reminderDal = reminderDal;
        }

        public void AddReminder(AddReminderDTO addReminderDTO)
        {
            Reminder reminder = new()
            {
                To = addReminderDTO.To,
                Content = addReminderDTO.Content,
                SendAt = addReminderDTO.SendAt,
                Method = addReminderDTO.Method,
                IsSent = addReminderDTO.IsSent
            };
            _reminderDal.Add(reminder);
        }



        public List<Reminder> GetAllReminders()
        {
            return _reminderDal.GetAll();
        }

        public Reminder GetReminderById(int id)
        {
            return _reminderDal.Get(x => x.Id == id);
        }

        public void RemoveReminder(Reminder reminder, int id)
        {
            var current = _reminderDal.Get(x => x.Id == id);
            _reminderDal.Delete(current);
        }

        public void UpdateReminder(Reminder reminder, int id)
        {
            var current = _reminderDal.Get(x => x.Id == id);
            current.To = reminder.To;
            current.Content = reminder.Content;
            current.SendAt = reminder.SendAt;
            current.Method = reminder.Method;
            current.IsSent = reminder.IsSent;
            _reminderDal.Update(current);
        }
    }
}
