using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RichBitch
{
    [Activity(Label = "Add cash")]
    public class AddCashActivity : Activity
    {
        private EditText amountEditText;
        private Spinner currencySpinner;
        private Button addButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddCashView);

            amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            currencySpinner = FindViewById<Spinner>(Resource.Id.currencySpinner);
            addButton = FindViewById<Button>(Resource.Id.addCashButton);

            addButton.Click += AddButtonOnClick;
            var enumValues = Enum.GetValues(typeof(Currency));
            var arrayForAdapter = enumValues.Cast<Currency>().Select(e => e.ToString()).ToArray();
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, arrayForAdapter);
            
            // Apply the adapter to the spinner
            currencySpinner.Adapter = adapter;
        }

        private void AddButtonOnClick(object sender, EventArgs eventArgs)
        {
            var amount = amountEditText.Text;
            var currency = currencySpinner.SelectedItem;

            
        }
    }
}