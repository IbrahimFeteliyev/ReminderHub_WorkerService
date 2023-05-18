using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddReminderDTO
    {
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
        public string Method { get; set; }
        public bool IsSent { get; set; }
    }
}
