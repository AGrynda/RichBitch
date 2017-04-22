using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace RichBitch
{
    public class PortmoneListAdapter : BaseAdapter
    {
        readonly Activity _context;
        private readonly List<Tuple<string, double>> _listItems;

        public PortmoneListAdapter(Activity context, List<Tuple<string, double>> balanceManagerPortmoneList)
        {
            _context = context;
            _listItems = balanceManagerPortmoneList;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate(
                           Resource.Layout.PortmoneListItemView, parent, false);

            var item = _listItems[position];

            var currencyTextView = view.FindViewById<TextView>(Resource.Id.currencyTextView);
            var amountTextView = view.FindViewById<TextView>(Resource.Id.amountTextView);
            currencyTextView.Text = item.Item1;
            amountTextView.Text = item.Item2.ToString();

            return view;
        }

        public override int Count => _listItems.Count;
    }
}