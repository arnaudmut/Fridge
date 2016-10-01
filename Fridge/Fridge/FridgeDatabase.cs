using System.Collections;
using System.Linq;
using SQLite;
using System.Collections.Generic;
using System.IO;

namespace Fridge
{
    /* <summary> FridgeDatabase utilise ADO.NET pour creer le la table[items] et creer, lire, mettre a jour, effacer les donnees */

    public class FridgeDatabase
    {
        public SQLiteConnection fridgeDb;
        public string path;
        static object locker = new object();

        ///<summary> 
        /// initialiser une nouvelle instance de <see cref="FrideDatabase"/>
        /// creer la base de donnees si elle n'exite pas
        /// </summary>
        public FridgeDatabase(SQLiteConnection conn)
        {
            fridgeDb = conn;
            fridgeDb.CreateTable<FridgeItem>();
        }

        public IEnumerable<FridgeItem> GetItems()
        {
            lock (locker)
            {
                return (from t in fridgeDb.Table<FridgeItem>() select t).ToList();
            }
        }

        public FridgeItem GetItem(int id)
        {
            lock (locker)
            {
                return fridgeDb.Table<FridgeItem>().FirstOrDefault(t => t.id == id);
            }
        }

        public int AddItem(FridgeItem item)
        {
            lock (locker)
            {
                if (item.id != 0)
                {
                    fridgeDb.Update(item);
                    return item.id;
                }
                else
                {
                    return fridgeDb.Insert(item);
                }

            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return fridgeDb.Delete<FridgeItem>(id);
            }
        }
    }
}
