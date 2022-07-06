using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chiyu.DTO
{

    public class DoorLogDto
    {
        public DateTime DateTime { get; set; }
        public int TerminalID { get; set; }
        public int DoorNo { get; set; }
        public int LogIndex { get; set; }
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
        public int ID { get; set; }
        public bool IsExported { get; set; }
        public int FKeyID { get; set; }
    }
}
