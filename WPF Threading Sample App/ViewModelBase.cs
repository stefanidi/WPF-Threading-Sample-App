﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WPF_Threading_Sample_App
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        Dispatcher _dispatcher = Application.Current.Dispatcher;

        protected void Send(Action action)
        {
            _dispatcher.Invoke(new Action(action));
        }

        protected void Queue(Action action)
        {
            _dispatcher.BeginInvoke(new Action(action));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
