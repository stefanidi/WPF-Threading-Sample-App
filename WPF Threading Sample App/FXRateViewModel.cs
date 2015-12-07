using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Threading_Sample_App
{
    public class FXRateViewModel : ViewModelBase
    {
        private readonly ITradeManager _tradeManager;
        private readonly IFXRateSource _fxRateSource;

        private readonly ObservableCollection<FXDealModel> _trades = new ObservableCollection<FXDealModel>();
        private FXRateModel _FXRate;

        public FXRateViewModel() //TODO: Dependency Injection in real world
        {
            _tradeManager = new TradeManager();
            _fxRateSource = new FXRateSource();

            _fxRateSource.FXRateUpdate += (s, e) => FXRate = new FXRateModel(e.Currency, e.Ask, e.Bid); //WPF will marshal to UI thread automatically here :)
        }

        public FXRateModel FXRate
        {
            get { return _FXRate; }
            set { _FXRate = value; RaisePropertyChanged("FXRate"); }
        }

        public ObservableCollection<FXDealModel> Trades
        {
            get { return _trades; }
        }

        public ICommand BuyTradeCommand
        {
            get
            {
                return new ActionCommand(()=>OnBookTradeClicked(TradeAction.Buy), ()=> FXRate != null);
            }
        }
        public ICommand SellTradeCommand
        {
            get
            {
                return new ActionCommand(()=>OnBookTradeClicked(TradeAction.Sell), () => FXRate != null);
            }
        }

        private void OnBookTradeClicked(TradeAction action)
        {
            _tradeManager.BookTradeAsync(FXRate, action, new Random().Next(0, 1000))
                .ContinueWith(d => Send(() => Trades.Add(d.Result))); //Manually Execute on the UI thread. 
            //We used dispatcher from the base class to ensure that we are adding to Observable collection on the UI thread. 
            //As WPF does not automagically switch to UI thread on the standard Observable Collection.
        }
    }
}
