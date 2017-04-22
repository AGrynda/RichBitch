using Android.App;
using Android.OS;
using Android.Widget;
using Autofac;

namespace RichBitch
{
    [Activity(Label = "Portmone")]
    public class PortmoneListActivity : Activity
    {
        private BalanceManager _balanceManager;
        private ListView _portmoneListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PortmoneList);

            _balanceManager = DIService.Container.Resolve<BalanceManager>();
            _portmoneListView = FindViewById<ListView>(Resource.Id.portmoneList);

            var portmoneListAdapterAdapter = new PortmoneListAdapter(this, _balanceManager.PortmoneList);
            _portmoneListView.Adapter = portmoneListAdapterAdapter;

        }
    }
}