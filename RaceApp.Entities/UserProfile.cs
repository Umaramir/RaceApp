using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RaceApp.Entities
{
    public class UserProfile
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Photo { get; set; }

    }
}
