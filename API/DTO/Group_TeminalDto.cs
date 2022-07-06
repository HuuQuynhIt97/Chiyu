using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chiyu.DTO
{
    public class Group_TeminalDto
    {
        public int Group_ID { get; set; }
        public string Group_Name { get; set; }
        public List<int> TerminalID_List { get; set; }
    }
}
