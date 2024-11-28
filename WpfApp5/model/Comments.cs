using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.model
{
    internal class Comments
    {
        public int commentID {  get; set; }

        public string message { get; set; }
        public int masterID { get; set; }
        public int requestID { get; set; }
    }
}
