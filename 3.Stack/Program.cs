// 진입점을 제공하는 프로그램 클래스.
// Entry Point.
using System;

class Program
{
    static Random random;
    // 범위를 지정해 난수를 발생시키는 함수.
    static float GetRandomInRange(float min, float max)
    {
        // 난수 생성을 위한 Random 객체 생성.
        if (random == null)
        {
            random = new Random();
        }

        // 0.0 - 1.0 사이의 난수를 생성한 뒤, 전달 받은 min ~ max 범위로 난수 범위를 조정.
        float randomNumber = (float)random.NextDouble();
        randomNumber *= (max - min);
        randomNumber += min;

        // 난수 반환.
        return randomNumber;
    }

    static void Main(string[] args)
    {
        // 경험치 삽입.
        ExpStack<float> stack = new ExpStack<float>();

        //float random1 = GetRandomInRange(0f, 200f);
        //Console.WriteLine($" 첫 번째 게임 종료 - 현재 경험치 {random1}");
        //stack.Push(random1);
        //float random2 = GetRandomInRange(0f, 200f);
        //Console.WriteLine($" 첫 번째 게임 종료 - 현재 경험치 {random2}");
        //stack.Push(random2);
        //float random3 = GetRandomInRange(0f, 200f);
        //Console.WriteLine($" 첫 번째 게임 종료 - 현재 경험치 {random3}");
        //stack.Push(random3);

        for (int ix = 0; ix < 10; ++ix)
        {
            float exp = GetRandomInRange(100.0f, 150.0f);

            Console.WriteLine($"{ix + 1}번째 게임 종료 - 현재 경험치 { exp}");
            stack.Push(exp);
        }


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