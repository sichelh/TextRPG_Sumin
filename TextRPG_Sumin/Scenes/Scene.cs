using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Scene
{
    protected Player player;

    public Scene(Player player)
    {
        this.player = player;
    }

    public abstract void Run();
}