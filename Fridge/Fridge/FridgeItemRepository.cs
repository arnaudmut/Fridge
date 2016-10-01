using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Fridge
{
    public class FridgeItemRepository
    {
        public FridgeDatabase Db { get; } = null;

        public FridgeItemRepository(SQLiteConnection conn)
        {
            Db = new FridgeDatabase(conn);
        }

        public FridgeItem GetFridgeItem(int id)
        {
            return Db.GetItem(id);
        }

        public IEnumerable<FridgeItem> GetFridgeItems()
        {
            return Db.GetItems();
        } 

        public int AddFridgeItem(FridgeItem item)
        {
            return Db.AddItem(item);
        }

        public int DeleteFridgeItem(int id)
        {
            return Db.DeleteItem(id);
        }
    }
}
