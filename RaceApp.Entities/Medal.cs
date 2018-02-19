using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class Medal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Picture { get; set; }
    }
}
