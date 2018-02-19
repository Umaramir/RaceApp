using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class TransactionHistory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string details { get; set; }
    }
}
