using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IReminderManager
    {
        void AddReminder(AddReminderDTO addReminderDTO);
        void RemoveReminder(Reminder reminder, int id);
        void UpdateReminder(Reminder reminder, int id);
        List<Reminder> GetAllReminders();
        Reminder GetReminderById(int id);
    }
}
