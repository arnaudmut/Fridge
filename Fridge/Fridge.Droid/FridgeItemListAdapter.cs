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
    ///<summary>Adapter that presents fridge items in a row-view</summary>
    public class FridgeItemListAdapter : BaseAdapter<FridgeItem>
    {
        Activity context = null;
        IList<FridgeItem> Items = new List<FridgeItem>();

        public FridgeItemListAdapter(Activity context, IList<FridgeItem> items)
        {
            this.context = context;
            this.Items = items;
        }

        public override FridgeItem this[int position] => Items[position];

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count => Items.Count;

        public override Android.Views.View GetView(int position, Android.Views.View convertView,
            Android.Views.ViewGroup parent)
        {

            var item = Items[position];
            var view =
                (convertView ??
                 context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItemChecked, parent, false)) as
                    CheckedTextView;
            view.SetText(item.name == "" ? "<new item>" : item.name, TextView.BufferType.Normal);
            //view.Checked == item.Done
            return view;
        }
    }
}