using System;
using System.Collections.Generic;

namespace RichBitch
{
    public class CurrencyConverter
    {
        private readonly Dictionary<Tuple<Currency, Currency>, double> _exchangeRates;

        public CurrencyConverter()
        {
            _exchangeRates = new Dictionary<Tuple<Currency, Currency>, double>();
            Init();
        }

        private void Init()
        {
            _exchangeRates.Add(new Tuple<Currency, Currency>(Currency.PLN, Currency.USD), 0.25);
            _exchangeRates.Add(new Tuple<Currency, Currency>(Currency.EUR, Currency.USD), 1.1);
            _exchangeRates.Add(new Tuple<Currency, Currency>(Currency.UAH, Currency.USD), 0.037);
            _exchangeRates.Add(new Tuple<Currency, Currency>(Currency.USD, Currency.USD), 1.0);
            _exchangeRates.Add(new Tuple<Currency, Currency>(Currency.USD, Currency.PLN), 4.0);
            _exchangeRates.Add(new Tuple<Currency, Currency>(Currency.USD, Currency.EUR), 0.9);
            _exchangeRates.Add(new Tuple<Currency, Currency>(Currency.USD, Currency.UAH), 26.7);
        }

        public double Convert(Currency currencyFrom, Currency currencyTo, double amount)
        {
            var key = new Tuple<Currency, Currency>(currencyFrom, currencyTo);
            if (_exchangeRates.ContainsKey(key))
            {
                return amount * _exchangeRates[key];
            }

            return -1;
        }

        public void AddExchangeRate(Currency currencyFrom, Currency currencyTo, double rate)
        {
            var key = new Tuple<Currency, Currency>(currencyFrom, currencyTo);
            if (_exchangeRates.ContainsKey(key)) return;
            _exchangeRates.Add(key, rate);
        }
    }
}