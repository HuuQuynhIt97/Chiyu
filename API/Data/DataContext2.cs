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
    public class DataContext2 : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Group_Terminal> Group_Terminals { get; set; }
        public DataContext2(DbContextOptions<DataContext2> options) : base(options) { }
        
    }
}
