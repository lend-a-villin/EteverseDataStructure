class Program
{
    static void Main(string[] args)
    {
        // 생성.
        CustomList<int> list = new CustomList<int>();

        // 값 추가.
        for (int ix = 0; ix < 10; ++ix)
        {
            list.Add(ix + 1);
        }

        // 삭제.
        list.Remove(4);
        list.Remove(8);
        list.RemoveAt(1);

        // 출력.
        for (int ix = 0; ix < list.Count; ++ix)
        {
            Console.WriteLine($"[{ix}]={list[ix]}");
        }

        Console.WriteLine($"Size: {list.Count}");

        Console.ReadKey();
    }
}