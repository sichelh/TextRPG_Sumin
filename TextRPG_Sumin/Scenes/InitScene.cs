using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Sumin;

public class InitScene : Scene
{
    public InitScene(Player player) : base(player) { }

    public override void Run()
    {
        Console.Clear();

        TextHelper.PrintSceneTitle("[시작화면]");
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("\n이름을 입력하세요.");
        string playerName = InputHelper.ReadString();

        player.playerName = playerName;

        TextHelper.PrintSystemMessage($"\n\"{playerName}\"님 어서오세요.");
        Thread.Sleep(500);

        Console.Clear();

        TextHelper.PrintSceneTitle("[직업선택]");
        Console.WriteLine("원하시는 직업을 선택해주세요.\n");
        TextHelper.PrintSelectMessage(1, "Warrior");
        TextHelper.PrintSelectMessage(2, "Wizzard");
        TextHelper.PrintSelectMessage(3, "Archer");

        Console.WriteLine("\n원하시는 직업을 입력해주세요.");

        int selectClassAct = InputHelper.ReadInt(1, 3);

        player.chaClass = (CharacterClass)selectClassAct;
        TextHelper.PrintSystemMessage($"\n\"{player.chaClass}\"를 선택했습니다.");
        Thread.Sleep(500);

        SceneManager.Instance.ChangeScene<MenuScene>();
    }
}
