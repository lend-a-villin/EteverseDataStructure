using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

// 진입점(Entry Point)를 갖는 프로그램 클래스.
class Program
{
    static void Main(string[] args)
    {
        // 크기가 10인 배열 객체 생성.
        Space.Array array = new Space.Array(10);

        // 값 설정.
        for (int ix = 0; ix < array.Length; ++ix)
        {
            array.SetData(ix, ix + 1);
        }

        // 값 읽고 출력.
        for (int ix = 0; ix < array.Length; ++ix)
        {
            Console.WriteLine($"[{ix}] = {array.At(ix)} ");
            //array.SetData(ix, ix + 1);
        }

        Console.WriteLine();

        // 그냥 종료되지 말라고 추가하는 의미 없는 코드.
        Console.ReadKey();
    }
}