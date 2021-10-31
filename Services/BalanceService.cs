using System;

namespace HomeWork.Services
{
    public class BalanceService
    {
        private int _current;

        public int Current => _current;

        public void Put(int value)
        {
            _current += value;
        }

        public void Take(int value)
        {
            if (value > _current)
            {
                throw new ArgumentException("Out of balance");
            }

            _current -= value;
        }
    }
}