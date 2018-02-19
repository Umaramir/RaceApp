using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class Result
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdRace { get; set; }
        public int Ranking { get; set; }
        public int BIBno { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public TimeSpan RaceTime { get; set; }
        public int Distance { get; set; }
        public TimeSpan Pace { get; set; }

    }
}
