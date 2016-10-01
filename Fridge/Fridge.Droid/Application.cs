using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Environment = System.Environment;

namespace Fridge.Droid
{
    [Application]
    public class FridgeApp : Application
    {
        public static FridgeApp Current { get; private set; }
        public FridgeItemManager FridgeManager { get; set; }
        private SQLiteConnection _conn;

        public FridgeApp(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer) : base(handle, transfer)
        {
            Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();
            var sqliteFilename = "FridgeDb.db3";
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(libraryPath, sqliteFilename);
            _conn = new SQLiteConnection(path);
            FridgeManager = new FridgeItemManager(_conn);
        }
    }
}