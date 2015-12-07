using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Threading_Sample_App
{
    public class FXDealModel
    {
        public DateTime Time { get; set; }
        public TradeAction TradeAction { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public string Currency { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2} {3} @ {4}", Time, TradeAction, Amount, Currency, Rate);
        }
    }
    
}
