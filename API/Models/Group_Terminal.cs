using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chiyu.Models
{
    [Table("Group_Terminal")]
    public class Group_Terminal
    {
        [Key]
        public int ID { get; set; }
        public int Terminal_ID { get; set; }
        public int Group_ID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
