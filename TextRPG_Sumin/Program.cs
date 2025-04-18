using System.Buffers;
using System.Runtime.CompilerServices;

namespace TextRPG_Sumin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            SceneManager.Instance.Init(player);
        }
    }

}