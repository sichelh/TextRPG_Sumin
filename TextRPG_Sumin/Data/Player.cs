using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Sumin;

public enum CharacterClass
{
    Warrior = 1,
    Wizzard,
    Archer
}

public class Player
{
    
    public int level = 1;
    public string? playerName; //nullable 변수
    public CharacterClass chaClass;
    public int atk = 10; // 공격력
    public int def = 5; // 방어력
    public int hp = 100;
    public int gold = 1500;

    public List<Item> Inventory => ItemDatabase.Items.Where(i => i.IsPurchased).ToList();

    public int GetAddAttack()
    {
        //LINQ 사용: 조건에 맞는 아이템을 필터링하여 플레이어의 인벤토리 아이템 리스트에 넣고 그 값들을 더해서 리턴
        return Inventory 
            .Where(i => i.IsEquip && i.Type == ItemType.Weapon)
            .Sum(i => i.Value);
    }
    public int GetAddDefense()
    {
        return Inventory
            .Where(i => i.IsEquip && i.Type == ItemType.Armor)
            .Sum(i => i.Value);
    }

    public int TotalAttack => atk + GetAddAttack();
    public int TotalDefense => def + GetAddDefense();

}
