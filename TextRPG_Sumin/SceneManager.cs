using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SceneManager
{
    // 싱글톤
    private static SceneManager? instance;
    public static SceneManager Instance => instance ??= new SceneManager();

    private Player player;
    private Scene currentScene; // 현재 씬 만들어주기
    private List<Scene> sceneList = new();

    // 외부에서 new SceneManager 못하게
    private SceneManager() { }

    public void Init(Player player)
    {
        this.player = player;

        // 씬 list에 추가
        sceneList.Add(new InitScene(player));
        sceneList.Add(new MenuScene(player));
        sceneList.Add(new StatScene(player));
        sceneList.Add(new InventoryScene(player));
        sceneList.Add(new ShopScene(player));

        // 시작 씬 설정
        ChangeScene<InitScene>();
    }

    public void ChangeScene<T>() where T : Scene
    {
        foreach(Scene scene in sceneList)
        {
            if (scene is T t) 
            {
                currentScene = scene;
                currentScene.Run();
                return;
            }
        }
    }

    public Scene GetCurrentScene()
    {
        return currentScene;
    }
}
