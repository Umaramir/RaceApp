using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class Inbox
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Messages { get; set; }
    }
}
