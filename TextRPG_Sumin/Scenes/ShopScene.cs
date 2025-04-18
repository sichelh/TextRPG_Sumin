internal class ShopScene : Scene
{
    public ShopScene(Player player) : base(player){}
    public Item Item { get; set; }

    public override void Run()
    {
        List<Item> shopItems = ItemDatabase.Items;
        bool isPurchaseMode = false;

        while (true)
        {
            Console.Clear();

            TextHelper.PrintSceneTitle("[상점]");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

            TextHelper.PrintSceneSubTitle("[보유 골드]");
            Console.Write(player.gold);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" G");
            Console.ResetColor();

            if (isPurchaseMode)
            {
                TextHelper.PrintSceneActiveSubTitle("\n[아이템 목록 - 구매하기]\n");
                TextHelper.PrintItem(shopItems, true);
            }
            else
            {
                TextHelper.PrintSceneSubTitle("\n[아이템 목록]\n");
                TextHelper.PrintItem(shopItems, false);
                TextHelper.PrintSelectMessage(1, "아이템 구매");
            }

            TextHelper.PrintSelectMessage(0, "나가기");

            Console.WriteLine("\n원하시는 행동을 입력해주세요.");

            int shopAct = InputHelper.ReadInt(0, isPurchaseMode? shopItems.Count : 1);

            if (!isPurchaseMode && shopAct == 0) // 구매 모드 아닐 때 나가기
            {
                SceneManager.Instance.ChangeScene<MenuScene>();
                return;
            }

            if (!isPurchaseMode && shopAct == 1) // 구매 모드 아닐 때 구매 모드 On
            {
                isPurchaseMode = true;
                continue;
            }

            if (isPurchaseMode && shopAct == 0) // 구매 모드일 때 구매모드 Off
            {
                isPurchaseMode = false;
                continue;
            }

            if (isPurchaseMode) // 구매모드 일 때 구매
            {
                Item selectedItem = ItemDatabase.Items[shopAct - 1];

                if (selectedItem.IsPurchased)
                {
                    TextHelper.PrintErrorMessage("\n이미 구매한 아이템입니다.");
                    Thread.Sleep(500);
                    continue;
                }

                if (player.gold < selectedItem.Price)
                {
                    TextHelper.PrintErrorMessage("\n골드가 부족합니다.");
                    Thread.Sleep(500);
                    continue;
                }

                TextHelper.PrintSystemMessage($"\n[{selectedItem.Name}] 구매를 완료했습니다.");
                player.gold -= selectedItem.Price;
                selectedItem.IsPurchased = true;
                Thread.Sleep(500);
            }
            
        }
    }

    
}