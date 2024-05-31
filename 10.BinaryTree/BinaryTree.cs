using System;

public class BinaryTree<T> 
{
    // 필드.
    // 루트 노드.
    private Node<T> root;

    // 왼쪽 자손 노드.
    public Node<T> Left
    {
        get
        {
            return root.Left;
        }
    }
    // 오른쪽 자손 노드.
    public Node<T> Right
    {
        get
        {
            return root.Right;
        }
    }

    // 메시지 - (공개 메소드) - 인터페이스(명세 - 약속).
    // 객체는 자유를 보장받은 애들, 메시지를 통해 소통한다.
    // 함수의 반환형(자료형과 함수에서 전달받는 파라미터의 개수 및 타입이 약속이 된다.
    
    // 생성 - 생성자.
    public BinaryTree(T data)
    {
        // 루트 노드 생성.
        root = new Node<T>(data);
    }

    // 자손은 아래의 공개 메소드에 따라서 루트 아래에 추가되는 방식으로 구현.
    // 왼쪽 자손 추가.
    public void AddLeftChild(T data, Node<T> parent = null)
    {
        AddLeftChild(new Node<T>(data), parent);
    }

    public void AddLeftChild(Node<T>  child, Node<T> parent = null)
    {
        // 부모 노드 지정.
        child.Parent = parent == null? root : parent;
        // 위에서 지정한 부모의 왼쪽 자손으로 새 노드를 추가.
        child.Parent.AddLeftChild(child);
    }

    // 오른쪽 자손 추가.
    public void AddRightChild(T data, Node<T> parent = null)
    {
        AddRightChild(new Node<T>(data), parent);
    }

    public void AddRightChild(Node<T> child, Node<T> parent = null)
    {
        // 부모 노드 지정.
        child.Parent = parent == null ? root : parent;
        // 위에서 지정한 부모의 오른쪽 자손으로 새 노드를 추가.
        child.Parent.AddRightChild(child);
    }
    // 순회 (전위 / 중위 / 후위) - 부모의 위치가 핵심.
    public void PreorderTraverse(int depth = 0)
    {
        PreorderTraverseRecursive(root, depth);
    }

    // 재귀 순회 메소드.
    // 뎁스 0-2단계까지만 하나하나 그려가며 검증하다 보면 속도가 늘 것이다.
    private void PreorderTraverseRecursive(Node<T> node, int depth = 0)
    {
        // 종료(탈출) 조건 확인.
        if (node == null)
        {
            return;
        }

        // 출력.
        for (int ix = 0; ix < depth; ++ix)
        {
            Console.Write("  ");
        }

        Console.WriteLine($"{node.Data}");

        // 왼쪽 자손 방문.
        PreorderTraverseRecursive(node.Left, depth + 1);

        // 오른쪽 자손 방문.
        PreorderTraverseRecursive(node.Right, depth + 1);
    }

    // 중위 순회 메소드.
    public void InorderTraverse(int depth = 0)
    {
        InorderTraverseRecursive(root, depth);
    }

    // 재귀 순회 메소드.
    // 뎁스 0-2단계까지만 하나하나 그려가며 검증하다 보면 속도가 늘 것이다.
    private void InorderTraverseRecursive(Node<T> node, int depth = 0)
    {
        // 종료(탈출) 조건 확인.
        if (node == null)
        {
            return;
        }

        // 왼쪽 자손 방문.
        InorderTraverseRecursive(node.Left, depth + 1);

        // 출력.
        for (int ix = 0; ix < depth; ++ix)
        {
            Console.Write("  ");
        }

        Console.WriteLine($"{node.Data}");

        // 오른쪽 자손 방문.
        InorderTraverseRecursive(node.Right, depth + 1);
    }

    // 후위 순회 메소드.
    public void PostorderTraverse(int depth = 0)
    {
        PostorderTraverseRecursive(root, depth);
    }

    // 재귀 순회 메소드.
    // 뎁스 0-2단계까지만 하나하나 그려가며 검증하다 보면 속도가 늘 것이다.
    private void PostorderTraverseRecursive(Node<T> node, int depth = 0)
    {
        // 종료(탈출) 조건 확인.
        if (node == null)
        {
            return;
        }

        // 왼쪽 자손 방문.
        PostorderTraverseRecursive(node.Left, depth + 1);

        // 오른쪽 자손 방문.
        PostorderTraverseRecursive(node.Right, depth + 1);

        // 출력.
        for (int ix = 0; ix < depth; ++ix)
        {
            Console.Write("  ");
        }

        Console.WriteLine($"{node.Data}");
    }


    // 탐색(검색) - Search / Find / Select.
    public bool Find(T data, out Node<T> outNode)
    {
        // 재귀적으로 탐색.
        return FindRecursive(data, root, out outNode);
    }

    // 검색 재귀 메소드.
    // T data : 검색할 값.
    // Node<t> node : 현재 검색 대상이 되는 노드.
    // outNode<T> outNode : 검색이 성공했을 때 반환(설정)할 노드 변수.
    private bool FindRecursive(T data, Node<T> node, out Node<T> outNode)
    {
        // 종료 조건 확인.
        if (node == null)
        {
            outNode = null;
            return false;
        }
        // 전위 순회 방식으로 검색.
        if (node.Data.Equals(data))
        {
            outNode = node;
            return true;
        }
        // 재귀적으로 검색을 이어서 진행. 좌 -> 우 순서로.

        bool result = FindRecursive(data, node.Left, out outNode);
        if (result)
        {
            return true;
        }

        result = FindRecursive(data, node.Right, out outNode);
        if (result)
        {
            return true;
        }

        // 검색 실패.
        outNode = null;
        return false;
    }

    // 삭제.
    public bool DeleteNode(T data)
    {
        // 삭제할 노드 검색 시도.
        bool result = Find(data, out Node<T> deleteNode);
        // 검색에 성공했으면 해당 노드 삭제.
        if (result == true)
        {
            deleteNode.Destroy();
            return true;
        }

        // 검색에 실패했으면 삭제 실패 반환.
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("삭제할 노드를 찾지 못했습니다.");
        Console.ForegroundColor= ConsoleColor.White;

        return false;
    }
}
