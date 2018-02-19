using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RaceApp.Entities;

namespace Services.Data.Helpers
{
    public class RaceAppDb : DbContext
    {
        public RaceAppDb(DbContextOptions<RaceAppDb> options) : base(options)
        { }

        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<Charity> Charity { get; set; }
        public DbSet<Partners> Partners { get; set;}
        public DbSet<Result> Result { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<RaceCart> RaceCart { get; set; }
        public DbSet<TransactionHistory> TransactionHistory { get; set; }
        public DbSet<Submit> Submit { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Inbox> Inbox { get; set; }
        public DbSet<MyRace> MyRace { get; set; }
        public DbSet<Judge> Judge { get; set; }
        public DbSet<Medal> Medal { get; set; }
        public DbSet<DoorPrize> DoorPrize { get; set; }
    }
}
