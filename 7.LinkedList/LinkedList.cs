// 연결 리스트는 노드를 통해서 데이터를 저장한다. 노드는 데이터 필드 /링크 필드를 가지고 있다.
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class LinkedList<T>
{
    // node 클래스
    class Node //링크드 리스트만 접근할 수 있는 클래스.
    {
        // 필드는 감춰야 하지만, 링크드리스트에서만 쓸 거기 때문에 편의상 퍼블릭으로 작성했다.
        // 데이터 필드.
        public T Data {  get; set; }

        // 링크 필드.
        public Node Next { get; set; }
        public Node()
        {
            Data = default(T);
            Next = null;

            
        }
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    // 필드.

    // 연결 리스트의 첫 부분을 나타내는 노드 변수.
    private Node head = null;

    // 연결 리스트에 저장된 요소의 수를 추적하는 변수.
    private int count = 0;


    // 공개 프로퍼티.
    // 연결 리스트에 저장된 요소의 수를 반환하는 프로퍼티.
    public int Count { get { return count; } }
    // 메시지 (공개 메소드) - 인터페이스.

    // 생성 - 생성자.

    public LinkedList()
    {
        head = null;
        count = 0;
    }

    // 연결 리스트 첫 부분에 데이터를 삽입하는 함수.
    public void AddToHead(T data)
    {
        // 새 노드 생성.
        Node newNode = new Node(data);
        // 생성한 노드 삽입.
        // 경우의 수 1 head가 없는 경우(null인 경우)
        if (head == null)
        {
            head= newNode;
        }
        // 경우의 수 2 head가 있는 경우(null이 아닌 경우).
        else
        {
            // 새 노드의 다음 도드를 기존의 head로 지정.
            newNode.Next = head;

            // head를 새로운 노드로 업데이트.
            head = newNode;
        }
        count++;
    }


    // 연결 리스트 마지막에 데이터를 삽입하는 함수.
    public void AddToLast(T data)
    {
        // 새 노드 생성.
        // 참조엔 주소값이 들어가는데, 주로 int로 들어간다.
        Node newNode = new Node(data);
        // 마지막 위치에 노드 삽입.

        // 경우의 수1 - head가 없는 경우 (null인 경우).
        if (head == null)
        {
            head = newNode;
        }
        // 경우의 수 2 - head가 있는 경우 (null이 아닌 경우).
        else
        {
            // 삽입할 위치 검색.
            Node current = head;
            while(current.Next != null)
            {
                current = current.Next;
            }
            // 데이터 삽입.
            current.Next = newNode;
        }
        count++;
    }
    // 값을 검색해서 노드를 삭제하는 함수. 인덱스로 할 수도 있다.
    public bool DeleteNode(T data)
    {
        // 경우의 수 1 - 리스트가 빈 경우.
        if (head == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("오류. 리스트가 비어 있어 삭제가 불가능합니다.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }
        // 검색.
        Node current = head;
        Node trail = null;
        while (current.Next != null)
        {
            // 삭제할 데이터와 노드의 데이터를 비교.
            if (current.Data.Equals(data))
            {
                break;
            }
            // 지금 데이터를 이전 데이터 추적용으로 남김.
            trail = current;
            // 삭제할 데이터를 찾지 못했으면 그 다음 위치로 이동.
            current = current.Next;
        }
        // 경우의 수 2-1 - 리스트가 비어 있지 않고, 값을 찾았는데, 찾은 노드가 head인 경우.
        if (current != null && current == head)
        {
            head = head.Next;
        }
        // 경우의 수 2-2 - 리스트가 비어 있지 않고, 값을 찾았는데, 찾은 노드가 head가 아닌 경우.
        else if (current != null && current != head)
        {
            trail.Next = current.Next;
            current.Next = null;
        }
        // 경우의 수 3 - 리스트가 비어 있지 않은데, 값을 못 찾은 경우.
        else if (current == null) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"오류: 값 {data}의 몫을 가진 항목을 찾지 못했습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        count--;
        return true;
    }
    // 특정 값이 존재하는지 검색을 하는 함수.
    public bool Find(T data)
    {
        if (head == null)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("오류 : 리스트가 비어 있어 검색에 실패했습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }
        // 검색 - 순차 검색(성능이 안 좋다).
        Node current = head;
        Node trail = null;
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                return true;
            }
            // 다음 위치로 이동해서 검색 반복.
            trail = current;
            current = current.Next;

        }
        return false;
    }
    // 데이터 출력 함수.
    public void Print()
    {
        // 예외처리.
        if (head == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("오류 : 리스트가 비어 있어 출력할 데이터가 없습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        // 그 다음 노드로 한 칸씩 이동하며 출력.
        Node current = head;
        while (current != null)
        {
            Console.Write($"{current.Data} ");
            current = current.Next;
        }
        Console.WriteLine();
    }

}
