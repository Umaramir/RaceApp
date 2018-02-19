using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SQLite;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class Charity
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Picture { get; set; }
        public string Video { get; set; }
        public string Messages { get; set; }
    }
}
