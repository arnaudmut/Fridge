using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fridge.Droid;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content;

namespace Fridge.Droid
{
    /// <summary>
    /// view/edit a fridge item
    /// </summary>
    [Activity(Label = "FridgeItemDetailsScreen")]
    class FridgeItemScreen : Activity
    {
        FridgeItem item = new FridgeItem();
        Button _cancelDeleteButton;
        EditText _notesEditText;
        EditText _nameEditText;
        Button _dateSelectButton;
        Button _saveButton;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            int itemId = Intent.GetIntExtra("Item.Id", 0);
            if (itemId > 0)
            {
                item = FridgeApp.Current.FridgeManager.GetFridgeItem(itemId);
            }
            //set our layout to be the homme screen
            SetContentView(Resource.Layout.ItemDetails);
            _nameEditText = FindViewById<EditText>(Resource.Id.NameText);
            _notesEditText = FindViewById<EditText>(Resource.Id.NotesText);
            _saveButton = FindViewById<Button>(Resource.Id.SaveButton);

            //find all our controls
            _cancelDeleteButton = FindViewById<Button>(Resource.Id.CancelDeleteButton);

            //set the cancel delete based on wether or not it's an existing task
            CancelDeleteButton.Text = (item.id == 0 ? "Cancel" : "Delete");
            _nameEditText.Text = item.name;
            //_notesEditText.Text = item.notes;

            //button clicks
            _cancelDeleteButton.Click += (sender, e) => { CancelDelete(); };
            _saveButton.Click += (sender, e) => { Save(); };
        }

        void Save()
        {
            item.name = _nameEditText.Text;
            //item.notes = _notesEditText.Text;
            FridgeApp.Current.FridgeManager.AddFridgeItem(item);
            Finish();
        }

        void CancelDelete()
        {
            if (item.id != 0)
            {
                FridgeApp.Current.FridgeManager.DeleteFridgeItem(item.id);
            }
            Finish();
        }

    }
}