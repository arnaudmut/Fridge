using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Fridge.Droid
{
    /// <summary>
    /// main ListView screen displays a list of tasks, plus [Add] button
    /// </summary>
    [Activity(Label = "Fridge", MainLauncher = true, Icon = "@drawable/icon")]
    class HomeScreen : Activity
    {
        FridgeItemListAdapter itemList;
        IList<FridgeItem> items;
        Button addItemButton;
        private ListView itemListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //set our layout to be the home screen
            SetContentView(Resource.Layout.HomeScreen);
             
            //find our controls
            itemListView = FindViewById<ListView>(Resource.Id.ItemList);
            addItemButton = FindViewById<Button>(Resource.Id.AddButton);

            //wire up add task button handler
            if (addItemButton != null)
            {
                addItemButton.Click += (sender, e) =>
                {
                    StartActivity(typeof (FridgeItemScreen));
                };
            }
            //wire up item click handler
            if (itemListView != null)
            {
                itemListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
                {
                    var itemDetails = new Intent(this, typeof (FridgeItemScreen));
                    itemDetails.PutExtra("ItemID", items[e.Position].id);
                    StartActivity(itemDetails);
                };
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            items = FridgeApp.Current.FridgeManager.GetFridgeItems();

            //create our adapter
            itemList = new FridgeItemListAdapter(this,items);

            //hook up adapter to our ListView
            itemListView.Adapter = itemList;
        }
    }
}