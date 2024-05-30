public class Program
{
    // 간단한 해시 함수 예시.
    // 문자열을 입력받아서 int 키를 생성하는 함수.
    // 해시가 뭔지, 해시테이블이 뭔지 설명할 수 있는 걸 많이 요구한다.
    static int GetSimpleStringHash(string keyInput)
    {
        int hash = 0;
        foreach (char c in keyInput)
        {
            // 문자열 내부 각 문자의 ASCII 숫자 값을 더하기.
            hash += (int)c;
        }

        return hash;
    }

    static void Main(string[] args)
    {
        //// 해시함수 테스트.
        //string input = "Hello, World~!";
        //// 이런 식으로 다른 문자열이더라도 같은 해시 값을 가지는 경우가 생길 수 있다.
        //// 이 때의 충돌 해결 방법이 체이닝과 오픈 어드레싱이다.
        //string input1 = "Hellp, Wnrld~!";
        //int hash = GetSimpleStringHash(input);

        //Console.WriteLine($"{input}에 대한 해시: {hash}");
        
        //Console.WriteLine($"{input1}에 대한 해시: {hash}");
        
        // 해시테이블 객체 생성.
        HashTable<string, string> table = new HashTable<string, string>();

        //// 데이터 추가.
        //table.Add("Ronnie", "020-2081-1224");
        //table.Add("Ronnie", "020-2231-1224");
        //table.Add("Kevin", "020-3352-3263");
        //table.Add("Baker", "020-3277-1356");
        //table.Add("Taejun", "020-9374-8923");

        //// 출력.
        //table.Print();

        //// 검색.
        //if (table.Find("Ronnie", out Pair<string, string> pair))
        //{
        //    Console.WriteLine($"검색결과: {pair.Key}, {pair.Value}");
        //}

        //// 삭제.
        //table.Delete("Ronnie");
        //table.Delete("Kevin");

        //// 출력.
        //table.Print();

        // 게임에서 활용할 가능성이 있으니 기억해두면 좋다.
        // 게임에서 일정 범위 내에서 반복되는 인덱스가 필요한 경우에.
        int index = 0;
        int count = 19;
        while (true)
        {
            index++;
            Console.WriteLine($"index: {index}, index % count = {index % count}");
            Thread.Sleep(200);
        }
        Console.ReadKey();
    }
}