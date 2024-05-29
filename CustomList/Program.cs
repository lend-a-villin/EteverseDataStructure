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
        //for (int ix = 0; ix < list.Count; ++ix)
        //{
        //    Console.WriteLine($"[{ix}]={list[ix]}");
        //}

        // 출력.
        foreach (var item in list)
        {
            Console.WriteLine($"{item}");
        }
        
        // heap에 박싱하고 언박싱이 계속 일어나게 된다.
        // foreach가 느린 것도 옛날 말이다. 하지만 그래도 최악을 가정했을 때를 알아둬서 나쁠 것 없다.
        foreach (int item in list)
        {
            Console.WriteLine($"{item}");
        }



        Console.WriteLine($"Size: {list.Count}");

        Console.ReadKey();
    }
}