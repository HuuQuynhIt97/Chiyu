using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chiyu.Models
{
    [Table("DoorLog")]
    public class DoorLog
    {
        [Key]
        public DateTime DateTime { get; set; }
        public System.Int64 TerminalID { get; set; }
        public System.Int64 DoorNo { get; set; }
        public System.Int64 LogIndex { get; set; }
        public string UserID { get; set; }
        public string EmployeeID { get; set; }
        public string CardNo { get; set; }
        public string EventAlarmCode { get; set; }
        public string InOutIndication { get; set; }
        public string VerificationSource { get; set; }
        public DateTime LogArrivalDateTime { get; set; }
        public int EventID { get; set; }
        public int InOutID { get; set; }
        public int VerificationID { get; set; }
        public System.Int64 ID { get; set; }
        public bool IsExported { get; set; }
        public int FKeyID { get; set; }
    }
}
