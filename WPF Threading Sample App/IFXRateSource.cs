using System;

namespace WPF_Threading_Sample_App
{
    public interface IFXRateSource
    {
        event EventHandler<FXRateEventArgs> FXRateUpdate;
    }
}