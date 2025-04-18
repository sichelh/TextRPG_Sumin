using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InputHelper
{
    public static string ReadString()
    {
        while (true)
        {
            TextHelper.PrintInputLine();
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }

            TextHelper.PrintErrorMessage("입력값이 유효하지 않습니다. 다시 입력해주세요.");
            Thread.Sleep(500);
        }
    }

    public static int ReadInt(int min, int max)
    {
        while (true)
        {
            TextHelper.PrintInputLine();
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int result) && int.Parse(input) >= min && int.Parse(input) <= max)
            {
                return result;
            }

            TextHelper.PrintErrorMessage("잘못된 입력입니다. 다시 입력해주세요.");
            Thread.Sleep(500);

        }
    }
}
