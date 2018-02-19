using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class Notification
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Race { get; set; }
        public DateTime CreatedDate { get; set; }
        public string StartRace { get; set; }
        public string PictureSmall { get; set; }
        public string Notes { get; set; }
    }
}
