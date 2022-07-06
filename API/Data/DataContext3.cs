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
    public class DataContext3 : DbContext
    {
        public DbSet<Door> Door { get; set; }
        public DbSet<DoorLog> DoorLog { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Terminal> Terminal { get; set; }
        public DataContext3(DbContextOptions<DataContext3> options) : base(options) { }
       
    }
}
