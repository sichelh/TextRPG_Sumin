public class InventoryScene : Scene
{
    public InventoryScene(Player player) : base(player){}

    public override void Run()
    {
        List<Item> myItems = ItemDatabase.Items.Where(i => i.IsPurchased).ToList(); //LINQ 사용, 구매한 아이템들로 리스트를 뽑아냄
        bool isEquipMode = false;

        while (true)
        {
            Console.Clear();

            TextHelper.PrintSceneTitle("[인벤토리]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            

            if (isEquipMode)
            {
                TextHelper.PrintSceneActiveSubTitle("\n[아이템 목록 - 장착 관리]\n");
                TextHelper.PrintItem(myItems, true);
            }
            else
            {
                TextHelper.PrintSceneSubTitle("\n[아이템 목록]\n");
                TextHelper.PrintItem(myItems, false);
                TextHelper.PrintSelectMessage(1, "장착 관리");
            }

            TextHelper.PrintSelectMessage(0, "나가기");

            Console.WriteLine("\n원하시는 행동을 입력해주세요.");

            int invAct = InputHelper.ReadInt(0, isEquipMode? myItems.Count : 1);

            if (!isEquipMode && invAct == 0) // 아이템 장착모드 아닐 때 나가기
            {
                SceneManager.Instance.ChangeScene<MenuScene>();
                return;
            }

            if (!isEquipMode && invAct == 1) // 아이템 장착모드 아닐 때 On
            {
                if (myItems.Count > 0) // 아이템 보유 수 체크
                {
                    isEquipMode = true;
                    continue;
                }
                TextHelper.PrintErrorMessage("보유한 아이템이 없습니다.");
                Thread.Sleep(500);
            }

            if (isEquipMode && invAct == 0) // 아이템 장착모드일 때 나가기 -> 장착모드 Off
            {
                isEquipMode = false;
                continue;
            }

            if (isEquipMode && invAct >= 1 && invAct <= myItems.Count) // 아이템 장착모드일 때 아이템 선택하면 장착
            {
                Item selectedItem = myItems[invAct - 1];
                ToggleEquip(selectedItem);
            }
        }
    }

    private void ToggleEquip(Item item) // 아이템 장착 및 해제 메서드
    {
        item.IsEquip = !item.IsEquip;

        string action = item.IsEquip ? "장착" : "장착 해제";
        TextHelper.PrintSystemMessage($"{item.Name}을(를) {action}했습니다.");
        Thread.Sleep(500);
    }
}