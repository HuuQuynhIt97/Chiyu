using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chiyu.Models
{
    [Table("Terminal")]
    public class Terminal
    {
        [Key]
        public System.Int64 TerminalID { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public bool IsAlive { get; set; }
        public bool IsTA { get; set; }
        public string IP { get; set; }
        public string SerialNo { get; set; }
        public int Port { get; set; }
        public int TerminalType { get; set; }
        public string? Department { get; set; }
        public int? InOut { get; set; }
    }
}
