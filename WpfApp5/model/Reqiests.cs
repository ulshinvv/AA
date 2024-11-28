using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.model
{
    internal class Reqiests
    {
        public int requestID { get; set; }
        public DateTime startDate { get; set; }
        public string orgTechType { get; set; }
        public string orgTechModel { get; set; }
        public string problemDescryption { get; set; }
        public string requestStatus { get; set; }
        public DateTime completionDate { get; set; }
        public int masterID { get; set; }
        public int clientID { get; set; }
    }
}
