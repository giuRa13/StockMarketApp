﻿using StockMarket.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }

        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;

            //Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Buy);
        }

    }
}
