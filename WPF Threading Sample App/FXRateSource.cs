using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WPF_Threading_Sample_App
{
    public class FXRateSource : IFXRateSource
    {
        private readonly Timer _timer;
        private Random r = new Random();
        private readonly string[] _currencies = { "AUDUSD", "EURGBP", "USDNZD" };
        public FXRateSource()
        {
            _timer = new Timer(700);
            _timer.Elapsed += (s, e) =>
            {
                if (FXRateUpdate != null)
                {
                    var mid = r.NextDouble() * 34;// 34 is just to make it more realistic.
                    FXRateUpdate(this, new FXRateEventArgs(_currencies[r.Next(0, 2)], (decimal)(mid - 0.1), (decimal)(mid + 0.1)));
                }
            };
            _timer.Start();
        }
        public event EventHandler<FXRateEventArgs> FXRateUpdate;
    }
}
