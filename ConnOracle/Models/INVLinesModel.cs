using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnOracle.Models
{
    public class INVLinesModel
    {
        public string invoice_num { get; set; }
        public int line_number { get; set; }

        public int amount { get; set; }

        public string account_segment { get; set; }

        public string description { get; set; }
    }
}