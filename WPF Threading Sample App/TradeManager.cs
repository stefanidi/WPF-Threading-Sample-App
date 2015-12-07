using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPF_Threading_Sample_App
{
    public class TradeManager : ITradeManager
    {
        public Task<FXDealModel> BookTradeAsync(FXRateModel deal, TradeAction action, decimal amount)
        {
            return Task.Run(() => BookDealFekeAndSlowly(deal, action, amount));
        }

        private FXDealModel BookDealFekeAndSlowly(FXRateModel deal, TradeAction action, decimal amount)
        {
            Thread.Sleep(1500);
            return new FXDealModel()
            {
                Amount = amount,
                Currency = deal.Currency,
                Rate = action == TradeAction.Buy ? deal.Ask : deal.Bid,
                Time = DateTime.Now, //Use UTC
                TradeAction = action,
            };
        }
    }
}
