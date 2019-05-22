using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ListToDoo.Models
{
    [Table("Reminder")]
    public class Reminder
    {   

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(5000)]
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
