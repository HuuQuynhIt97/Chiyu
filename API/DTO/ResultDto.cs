using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chiyu.DTO
{

    public class ResultDto
    {
        public string GuestID { get; set; }
        public string CardNo { get; set; }
        public string GuestName { get; set; }
        public string Department { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string EntryDoor { get; set; }
        public string EventDescription { get; set; }
        public string VerificationSource { get; set; }
    }
}
