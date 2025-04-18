using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ItemDatabase
{
    public static List<Item> Items = new List<Item>()
    {
        new Item{Name="수련자 갑옷", Type = ItemType.Armor, Value = 5, Description = "수련에 도움을 주는 갑옷입니다.", Price = 500, IsPurchased = false, IsEquip = false},
        new Item{Name="무쇠갑옷", Type = ItemType.Armor, Value = 9, Description = "무쇠로 만들어져 튼튼한 갑옷입니다.", Price = 1000, IsPurchased = false, IsEquip = false },
        new Item{Name="스파르타의 갑옷", Type = ItemType.Armor, Value = 15, Description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", Price = 3500, IsPurchased = false, IsEquip = false },
        new Item{Name="낡은 검", Type = ItemType.Weapon, Value = 2, Description = "쉽게 볼 수 있는 낡은 검 입니다.", Price = 600, IsPurchased = false, IsEquip = false },
        new Item{Name="청동 도끼", Type = ItemType.Weapon, Value = 5, Description = "어디선가 사용됐던거 같은 도끼입니다.", Price = 1500, IsPurchased = false, IsEquip = false },
        new Item{Name="스파르타의 창", Type = ItemType.Weapon, Value = 7, Description = "스파르타의 전사들이 사용했다는 전설의 창입니다.", Price = 3000, IsPurchased = false, IsEquip = false }
    };
}
