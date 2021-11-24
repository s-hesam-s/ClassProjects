using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProgram
{
    class Transaction
    {
        public string Id { get; set; }
        public double Withdraw { get; set; }
        public double Deposit { get; set; }
        public DateTime DateTime { get; set; }
    }
}
