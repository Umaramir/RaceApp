using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace RaceApp.Entities
{
    public class RaceCart
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Items { get; set; }
        public int TotalItems { get; set; }
        public int Weight { get; set; }
        public string Method { get; set; }
        public string Service { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public int TotalAll { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Notes { get; set; }
    }
}
