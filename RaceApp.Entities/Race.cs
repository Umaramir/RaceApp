using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class Race
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Money { get; set; }
        public DateTime RegisDate { get; set; }
        public int IdBanner { get; set; }
        public int IdMedal { get; set; }
        public string Rules { get; set; }
        public string Information { get; set; }
        public string How { get; set; }
        public string IdDoorPrize { get; set; }
        public string IdCharity { get; set; }
    }
}
