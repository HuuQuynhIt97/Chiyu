using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chiyu.Models
{
    [Table("Door")]
    public class Door
    {
        [Key]
        public int DoorID { get; set; }
        public string Name { get; set; }
        public int TerminalID { get; set; }
        public int DoorIndex { get; set; }
        public string Note { get; set; }
        public bool IsTA { get; set; }
        public int FireGroupID { get; set; }
    }
}
