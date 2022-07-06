using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chiyu.Models
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
