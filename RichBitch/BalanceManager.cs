using System;
using System.Collections.Generic;
using System.Linq;

namespace RichBitch
{
    public class BalanceManager
    {
        private readonly CurrencyConverter _converter;
        private readonly ExchangeService _exchangeService;
        private readonly Dictionary<Currency, double> _portmone;

        public BalanceManager(CurrencyConverter currencyConverter)
        {
            _converter = currencyConverter;
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

        public List<Tuple<string, double>> PortmoneList => _portmone
            .Select(item => new Tuple<string, double>(item.Key.ToString(), item.Value))
            .ToList();

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
            _exchangeService.GetLatest();
            return _portmone.Sum(cash => _converter.Convert(cash.Key, currency, cash.Value));
        }
    }
}