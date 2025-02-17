using StockMarket.WPF.Commands;
using StockMarket.WPF.Models;
using StockMarket.WPF.ViewModels;
using StockMarket.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockMarket.WPF.States.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        {  
            get
            {
                return _currentViewModel;   
            }
            set 
            { 
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));    
            } 
        }
        
        public ICommand UpdateCurrentViewModelCommand { get; set; }


        public Navigator(IRootViewModelFactory viewModelFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelFactory);   
        }
        
        
        
        
        // Observabe obj
        /*public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/
    }
}
