using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
//using Array = Container.Array<int>; //System.Array가 있기 때문에 지정해줘야 한다. 혹은 Container.Array(10)과 같이 사용하거나. 제네릭 설정이 되어 있다면 T가 들어간 자리에 자료형 인자를 넣어주면 된다. 근데 여기서 설정하면 아래에서 Array를 불러다 썼을 때 int가 아니어도 못 찾아낸다. 따라서 일반적으로는 이 줄을 끄고 아래애다가  Conatainer.Array<int>로 쓰는 게 바람직하다.

// 진입점(Entry Point)를 갖는 프로그램 클래스.
class Program
{
    static void Main(string[] args)
    {
        // 크기가 10인 배열 객체 생성.
        Container.Array<int> array = new Container.Array<int>(10); // 만일 중간에 float이나 double 등이 필요한 경우, <> 안의 자료형만 바꿔주면 알아서 복사본을 떠 준다.

        // 값 설정.
        for (int ix = 0; ix < array.Length; ++ix)
        {
            //array.SetData(ix, ix + 1);
            array[ix] = ix + 1;//인덱서가 생기고 나면 이렇게 호출해도 전혀 문제 없다.
        }

        // 값 읽고 출력.
        for (int ix = 0; ix < array.Length; ++ix)
        {
            //Console.WriteLine($"[{ix}] = {array.At(ix)} ");
            Console.WriteLine($"[{ix}] = {array[ix]} ");
            //array.SetData(ix, ix + 1);
        }

        Console.WriteLine();

        // 그냥 종료되지 말라고 추가하는 의미 없는 코드.
        Console.ReadKey();
    }
}