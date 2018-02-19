using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data.Helpers
{
    public interface RaceSQLite
    {
        SQLiteConnection GetConnection();
    }
}
