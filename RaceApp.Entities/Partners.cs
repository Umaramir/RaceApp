using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class Partners
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set;}
        public string name { get; set; }
        public string logo { get; set; }
        public string Messages { get; set; }
        public string linkurl { get; set; }
    }
}
