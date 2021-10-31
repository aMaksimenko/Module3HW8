using System;
using HomeWork.Models;

namespace HomeWork.Services
{
    public class AccountService
    {
        private readonly User _user;
        private readonly BalanceService _balanceService;

        public AccountService(User user)
        {
            _user = user;
            _balanceService = new BalanceService();
        }

        public event EventHandler<string> OnBalanceUpdate;

        public void Put(int value)
        {
            _balanceService.Put(value);
            OnBalanceUpdate?.Invoke(this, $" >> {_user.Name}#{_user.Id} put {value}");
        }

        public void Take(int value)
        {
            try
            {
                _balanceService.Take(value);
                OnBalanceUpdate?.Invoke(this, $" << {_user.Name}#{_user.Id} took {value}");
            }
            catch (Exception e)
            {
                OnBalanceUpdate?.Invoke(this, $"!!! Operation for {_user.Name}#{_user.Id} terminated with error: {e.Message} !!!");
            }
        }
    }
}