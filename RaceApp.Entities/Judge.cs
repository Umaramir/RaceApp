using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class Judge
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public bool YesOrNo { get; set; }
        public string Notes { get; set; }
        public bool Disclaimer { get; set; }
    }
}
