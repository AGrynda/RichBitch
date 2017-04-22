using System.Collections.Generic;
using System.Linq;

namespace RichBitch
{
    public class BalanceManager
    {
        private readonly CurrencyConverter _converter;
        private readonly Dictionary<Currency, double> _portmone;

        public BalanceManager()
        {
            _converter = new CurrencyConverter();
            _portmone = new Dictionary<Currency, double>();
            Init();
        }

        private void Init()
        {
            _portmone.Add(Currency.PLN, 150);
            _portmone.Add(Currency.EUR, 120);
            _portmone.Add(Currency.UAH, 700);
            _portmone.Add(Currency.USD, 233);
        }

        public void Add(Currency currency, double amount)
        {
            if (_portmone.ContainsKey(currency))
            {
                _portmone[currency] += amount;
            }
            else
            {
                _portmone.Add(currency, amount);
            }
        }

        public double GetBalance(Currency currency = Currency.USD)
        {
            return _portmone.Sum(cash => _converter.Convert(cash.Key, currency, cash.Value));
        }
    }
}