// 진입점을 제공하는 프로그램 클래스.
// Entry Point.
class Program
{
    static void Main(string[] args)
    {
        // 경험치 삽입.
        ExpStack stack = new ExpStack();

        Console.WriteLine(" 첫 번째 게임 종료 - 현재 경험치 125.4");
        stack.Push(125.4f);
        Console.WriteLine(" 첫 번째 게임 종료 - 현재 경험치 187.4");
        stack.Push(187.4f);
        Console.WriteLine(" 첫 번째 게임 종료 - 현재 경험치 178.4");
        stack.Push(178.4f);

        // 값 추출 및 출력.
        int count = stack.Count;
        for (int ix = 0; ix < count; ++ix)
        {
            // 값 추출.
            if (stack.Pop(out float value))
            {
                Console.WriteLine($"현재 경험치: {value}");
            }
        }


        Console.ReadKey();
    }
}