using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Fridge
{
    ///<summary>abstaction classes on the data acces layers</summary>
    public class FridgeItemManager
    {
        public FridgeItemRepository Repository { get; }


        public FridgeItemManager(SQLiteConnection conn)
        {
            Repository = new FridgeItemRepository(conn);
        }

        public FridgeItem GetFridgeItem(int id)
        {
            return Repository.GetFridgeItem(id);
        }

        public IList<FridgeItem> GetFridgeItems()
        {
            return new List<FridgeItem>(Repository.GetFridgeItems());
        }

        public int AddFridgeItem(FridgeItem item)
        {
            return Repository.AddFridgeItem(item);
        }

        public int DeleteFridgeItem(int id)
        {
            return Repository.DeleteFridgeItem(id);
        }
    }
}