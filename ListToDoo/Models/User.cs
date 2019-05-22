using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ListToDoo.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int UserId { get; set; }
        
        public string Mail { get; set; }
        
        public string fullName { get; set; }

        public string DateOfBirth { get; set; }

        public string Definition { get; set; }
        public string Password { get; set; }
    }
}
