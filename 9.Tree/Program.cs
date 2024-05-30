using System;
class Program
{
    static void PrintNode<T>(Node<T> node)
    {
        if (node.Parent == null)
        {
            Console.WriteLine($"{node.Data}");
        }
        else
        {
            Console.WriteLine($"- {node.Data}");
        }
    }

    static void Main(string[] args)
    {
        // 트리 생성.
        // 칠드런에 직접 접근하지 않고, "B"에 추가해 줘와 같이 하는 것이 좋다.
        // 검색 기능이 있어야 위의 작업을 할 수 있다.
        Tree<string> tree = new Tree<string>("A");
        
        tree.AddChild("B");
        tree.Children[0].AddChild("e");
        tree.Children[0].AddChild("f");
        tree.Children[0].AddChild("g");
        
        tree.AddChild("C");
        //tree.Children[1].AddChild("h");
        //tree.Children[1].AddChild("i");
        tree.AddChild("C", "h");
        tree.AddChild("C", "i");

        tree.AddChild("D");
        tree.AddChild("D", "j"); // 검색 기능을 통해 부모 노드가 있는지 검증하고, 추가하는 기능 이용.
        //tree.Children[2].AddChild("j");
        tree.AddChild("K", "l");

        // 전위 순회.
        // 람다를 사용한 방법.
        // 자료형 선언이 없고, =>로 람다를 쓰겠다고 선언. {} 안에 사용할 함수를 적는다. 함수를 넘겨줘야되는데 명확하게 프리오더트래버스가 요구하는 함수를 선언한 다음에 전달해도 되고(아래아래처럼) 혹은 바로 아래처럼 임시로 선언해도 된다.
        //tree.PreorderTraverse(node => { Console.WriteLine($"{node.Data}"); });
        
        tree.PostorderTraverse(PrintNode);

        if (tree.Find("f", out Node<string> outNode))
        {
            Console.WriteLine($"검색 성공. 부모: {outNode.Parent.Data}, 값: {outNode.Data}");
        }
        else
        {
            Console.WriteLine("검색에 실패했습니다.");
        }

        // 삭제.
        if (tree.Delete("B"))
        {
            Console.WriteLine($"삭제 성공.");
            tree.PreorderTraverse(node => { Console.WriteLine($"{node.Data}"); });
        }
        else
        {
            Console.WriteLine("삭제에 실패했습니다.");
        }

        Console.ReadKey();
    }
}