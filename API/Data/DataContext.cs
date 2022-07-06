using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Chiyu.Models;
using Chiyu.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chiyu.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Door> Door { get; set; }

        public DbSet<DoorLog> DoorLog { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Terminal> Terminal { get; set; }
        public DbSet<Mailing> Mailings { get; set; }
        public DbSet<OC> OCs { get; set; }
        public DbSet<OCUser> OCUsers { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
