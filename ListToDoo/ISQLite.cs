using System;
using System.Collections.Generic;
using System.Text;

namespace ListToDoo
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
