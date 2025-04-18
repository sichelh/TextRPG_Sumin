using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Item
{
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public int Value { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public bool IsPurchased { get; set; }

    public bool IsEquip {  get; set; }

}
