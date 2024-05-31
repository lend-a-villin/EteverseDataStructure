using System;
class Program
{
    static void Main(string[] args)
    {
        // 트리 생성.
        BinarySearchTree tree = new BinarySearchTree();

        tree.Insert(10);

        tree.Insert(7);

        tree.Insert(11);

        tree.Insert(5);

        tree.Insert(5);

        tree.Insert(7);

        if (tree.Find(11))
        {
            Console.WriteLine("검색에 성공했습니다.");
        }
        else
        {
            Console.WriteLine("검색에 실패했습니다.");
        }

        tree.InorderTraverse();

        Console.ReadKey();
    }
}