using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Threading_Sample_App
{
    public class FXRateEventArgs : EventArgs
    {
        public FXRateEventArgs(string currency, decimal bid, decimal ask)
        {
            Currency = currency;
            Bid = bid;
            Ask = ask;
        }
        public string Currency { get; private set; }
        public decimal Bid { get; private set; }
        public decimal Ask { get; private set; }
    }
}
