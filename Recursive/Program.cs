using System;

public class Recursive
{
    // 재귀 함수.
    // 자기 자신을 호출하는 함수.
    // 재귀는 처음엔 귀찮아도 그림을 그려보는 게 좋다.
    // 메인에서 - 리커시브 펑션에 0 넣고 출력 - 리커시브 펑션이 - 리커시브 펑션에 1 넣고 출력 - 5가 될 때까지 - 5가 되면 종료 조건을 만나고 대기하던 상위 리커시브 펑션이 종료되며 메인으로 돌아감.
    // 스택은 빠르지만 용량이 작기 때문에 스택오버플로우를 주의해야 한다. 따라서 재귀나 무한루프는 탈출 지점부터 고려하고 시작해야 한다.
    static void RecursiveFunction(int count)
    {
        // 해결법.
        // 종료 조건 - 재귀함수랑 무한루프할 때는 아무 생각 없이 설정하고 시작해야 한다. 위의 이유 때문에.
        if (count == 5) 
        {
            return;
        }
        Console.WriteLine($"count: {count}");

        RecursiveFunction(count + 1);

    }
    static void Main(string[] args)
    {
        RecursiveFunction(0);
        Console.ReadKey();
    }
}