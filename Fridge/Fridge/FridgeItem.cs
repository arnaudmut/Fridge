using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Fridge
{[Table("Items")]
public class FridgeItem
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
            public  string name { get; set; }
            public DateTime expiryDate { get; set; }
        public  FridgeItem() { }

    }
}
