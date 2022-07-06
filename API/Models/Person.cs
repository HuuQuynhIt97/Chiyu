using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chiyu.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

    }
}
