﻿using StockMarket.Domain.Models;
using StockMarket.Domain.Services.Authentication;
using StockMarket.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.WPF.States
{
    public class Authenticator : ObservableObject, IAuthenticator 
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        private Account _currentAccount;
        public Account CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            private set
            {
                _currentAccount = value;
                OnPropertyChanged(nameof(CurrentAccount));
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }
        public bool IsLoggedIn => CurrentAccount != null;


        public async Task<bool> Login(string username, string password)
        {
            bool success = true;
            
            try
            {
                CurrentAccount = await _authenticationService.Login(username, password);
            }
            catch (Exception ) 
            { 
                success = false;
            }

            return success;
        }


        public void Logout()
        {
            CurrentAccount = null;
        }


        public Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            return _authenticationService.Register(email, username, password, confirmPassword);
        }
    }
}
