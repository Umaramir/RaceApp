using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class Submit
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Race { get; set; }
        public string UploadRoute { get; set; }
        public string Email { get; set; }
        public int DistanceCompleted { get; set; }
        public int Hour { get; set; }
        public int Min { get; set; }
        public int Sec { get; set; } 
        public string JournalPhoto { get; set; }
        public bool Disclaimer { get; set; }
    }
}
