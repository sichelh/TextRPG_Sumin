using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TextHelper
{
    public static void PrintSceneTitle(string title) //제목 출력
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(title);
        Console.ResetColor();
    }

    public static void PrintSceneSubTitle(string subTitle) //부제목 출력
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(subTitle);
        Console.ResetColor();
    }

    public static void PrintSceneActiveSubTitle(string subTitle) //다른 부제목 출력
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(subTitle);
        Console.ResetColor();
    }

    public static void PrintErrorMessage(string message) //입력 결과 오류 안내 메시지 출력
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintSystemMessage(string message) //입력 결과 안내 메시지 출력
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintSelectMessage(int number, string message) //입력 선택지 출력
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{number}. ");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(message);
        Console.ResetColor();

        Console.WriteLine();
    }

    public static void PrintInputLine()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write(">> ");
        Console.ResetColor();
    }

    public static void PrintStat(string statName, int total, int addValue)
    {
        Console.Write($"{statName} : {total}");
        if ( addValue > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($" (+{addValue})");
        }
        Console.WriteLine();
        Console.ResetColor();

    }

    public static void PrintItem(List<Item> items, bool withIndex = false) //item목록 출력
    {
        Scene currentScene = SceneManager.Instance.GetCurrentScene();

        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("- ");

            if (withIndex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{i + 1}. ");
            }
            
            if (currentScene is InventoryScene && item.IsEquip)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[E] ");
            }
            else
            {
                Console.Write("");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{item.Name,-10}");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" | ");

            switch (item.Type)
            {
                case ItemType.Armor:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("방어력 ");
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.Write($"+{item.Value,-3}");
                    break;
                case ItemType.Weapon:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("공격력 ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"+{item.Value,-3}");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("기타 효과 ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"+{item.Value,-3}");
                    break;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" | ");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{item.Description,-30}");

            if (currentScene is ShopScene)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" | ");

                if (item.IsPurchased)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("구매완료");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"{item.Price} ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("G");
                }
                
            }

            Console.WriteLine();

            Console.ResetColor();
        }
        Console.WriteLine();
    }
}
