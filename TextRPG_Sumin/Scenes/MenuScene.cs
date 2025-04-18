using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MenuScene : Scene
{
    public MenuScene(Player player) : base(player) { }

    public enum Scenes
    {
        Stat = 1,
        Inventory,
        Shop
    }
    public override void Run()
    {
        Console.Clear(); //콘솔 버퍼와 해당 콘솔 창에서 표시 정보를 지운다.

        TextHelper.PrintSceneTitle("[메뉴 화면]");
        Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

        TextHelper.PrintSelectMessage(1, "상태 보기");
        TextHelper.PrintSelectMessage(2, "인벤토리");
        TextHelper.PrintSelectMessage(3, "상점");

        Console.WriteLine("\n원하시는 행동을 입력해주세요.");

        int startAct = InputHelper.ReadInt(1, 3);

        switch ((Scenes)startAct)
        {
            case Scenes.Stat:
                SceneManager.Instance.ChangeScene<StatScene>();
                break;
            case Scenes.Inventory:
                SceneManager.Instance.ChangeScene<InventoryScene>();
                break;
            case Scenes.Shop:
                SceneManager.Instance.ChangeScene<ShopScene>();
                break;
        }
    }
}
