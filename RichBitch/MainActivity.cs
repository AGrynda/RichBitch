using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Autofac;

namespace RichBitch
{
    [Activity(Label = "RichBitch", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private BalanceManager _balanceManager;
        private TextView _balanceTextView;
        private ImageButton _portmoneListButton;
        private ImageButton _addButton;
            
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _balanceManager = DIService.Container.Resolve<BalanceManager>();

            _balanceTextView = FindViewById<TextView>(Resource.Id.balanceTextView);
            _addButton = FindViewById<ImageButton>(Resource.Id.addButton);
            _portmoneListButton = FindViewById<ImageButton>(Resource.Id.portmoneButton);

            _portmoneListButton.Click += OnPortmoneButtonClick;
            _addButton.Click += OnPortmoneButtonClick;

            _balanceTextView.Text = _balanceManager.GetBalance() + " " + Currency.USD;
        }

        private void OnPortmoneButtonClick(object sender, EventArgs e)
        {
            StartActivity(typeof(PortmoneListActivity));
        }
    }
}

