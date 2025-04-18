using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StatScene : Scene
{
    public StatScene(Player player) : base(player) {}

    public override void Run()
    {
        Console.Clear();

        TextHelper.PrintSceneTitle("[상태보기]");
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nLv. " + player.level);

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write($"{player.playerName} ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"( {player.chaClass} )");

        Console.ResetColor();

        int addAtk = player.GetAddAttack();
        int addDef = player.GetAddDefense();

        Console.WriteLine();
        TextHelper.PrintStat("공격력", player.TotalAttack, addAtk);
        TextHelper.PrintStat("방어력", player.TotalDefense, addDef);
        Console.WriteLine($"체력 : {player.hp}");

        Console.WriteLine();
        Console.Write($"Gold : {player.gold} ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("G");
        Console.ResetColor();

        Console.WriteLine();

        TextHelper.PrintSelectMessage(0, "나가기");

        Console.WriteLine("\n원하시는 행동을 입력해주세요.");

        int startAct = InputHelper.ReadInt(0, 0);

        SceneManager.Instance.ChangeScene<MenuScene>();
    }
}