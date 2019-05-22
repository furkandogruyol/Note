using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ListToDoo.Models
{
    [Table("ToDo")]
    public class ToDo
    {   [AutoIncrement,PrimaryKey]
        public int id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(5000)]
        public string Body { get; set; }

        public bool IsDone { get; set; }
    }
}
