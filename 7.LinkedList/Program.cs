using System;

public class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> list = new LinkedList<int>();
        // System.Collections.Generic.LinkedList<>
        string? data;

        while (true)
        {
            Console.WriteLine("추가할 데이터를 입력해주세요(종료는 q)");

            data = Console.ReadLine();

            if (data == "q" || data == "Q")
            {
                break;
            }

            if (int.TryParse(data, out int outValue))
            {
                list.AddToLast(outValue);
                list.Print();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("데이터 입력을 잘못하셨습니다. 숫자만 입력이 가능합니다.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        while (true)
        {
            Console.WriteLine("삭제할 데이터를 입력해주세요(종료는 q)");

            data = Console.ReadLine();

            if (data == "q" || data == "Q")
            {
                break;
            }

            if (int.TryParse(data, out int outValue))
            {
                list.DeleteNode(outValue);
                list.Print();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("데이터 입력을 잘못하셨습니다. 숫자만 입력이 가능합니다.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        list.Print();

        Console.ReadKey();
    }
}

//using System.ComponentModel;

//public class Program
//{
//    static void Main(string[] args)
//    {
//        // 연결 리스트 생성.
//        LinkedList<int> list = new LinkedList<int>();

//        for (int ix = 0; ix <10; ++ix)
//        {
//            if ((ix + 1) %2 == 0)
//            {
//                list.AddToHead(ix + 1);
//            }
//            else
//            {
//                list.AddToLast(ix + 1);
//            }
//        }

//        list.Print();
//        Console.WriteLine($"{list.Count}개");

//        // 삭제.
//        list.DeleteNode(1);
//        list.DeleteNode(10);
//        list.DeleteNode(3);

//        Console.WriteLine("삭제 후 출력.");
//        list.Print();
//        Console.WriteLine($"{list.Count}개");

//        Console.WriteLine("찾을 숫자를 입력하세요.");

//        int findNum;

//        if (list.Find(10))
//        {
//            Console.WriteLine("해당 숫자 찾음");
//        }
//        else
//        {
//            Console.WriteLine("해당 숫자 못찾음");
//        }
//        Console.ReadKey();
//    }
//}