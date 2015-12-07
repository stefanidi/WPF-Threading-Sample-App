using System.Threading.Tasks;

namespace WPF_Threading_Sample_App
{
    public interface ITradeManager
    {
        Task<FXDealModel> BookTradeAsync(FXRateModel deal, TradeAction action, decimal amount);
    }
}