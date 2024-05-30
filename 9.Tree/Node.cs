public class Node<T>
{
    // 필드.
    // 데이터를 저장하는 데이터 필드.
    public T Data { get; set; }

    // 부모 링크 필드.
    public Node<T> Parent { get; set; }
    // 자손 링크 필드.
    public List<Node<T>> Children { get; set; }

    // 메시지 (공개 메소드) - 인터페이스.

    // 생성.
     public Node(T data = default(T))
    {
        Data = data;
        Parent = null;
        Children = new List<Node<T>>();
    }

    // 자손 노드 추가.(데이터만 입력받거나/ 노드를 입력받음).
    public void AddChild(T data)
    {
        // 아래 함수를 호출.
        AddChild(new Node<T>(data));
    }
    public void AddChild(Node<T> child)
    {
        // 추가할 자손의 부모를 나로 지정.
        child.Parent = this;

        // 자손으로 추가.
        Children.Add(child);
    }

    // 트리에서 노드 제거.
    public void Destroy()
    {
        // 부모의 자식 목록에서 나를 제거.
        if (Parent != null)
        {
            Parent.Children.Remove(this);
            //GC.Collect(); 메모리 비우는 걸 명시적으로 호출할 때 쓰는 건데, 메모리 부하가 높다. 게임에선 씬 넘기거나 메모리 정리가 필요할 때 로딩 씬 띄워놓고 사용한다.
        }
    }
}
