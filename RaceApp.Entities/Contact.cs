using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Notes { get; set; }
    }
}
