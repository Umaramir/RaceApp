using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class MyRace
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Race { get; set; }
        public string StartDate { get; set; }
        public string Rank { get; set; }
        public string BIBno { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string RaceTime { get; set; }
        public string Distance { get; set; }
        public string Pace { get; set; }
    }
 
}
