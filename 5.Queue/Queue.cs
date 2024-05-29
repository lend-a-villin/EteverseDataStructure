using System;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;
public class Queue<T>
{

    // 큐에서 사용할 데이터 컨테이너(배열).
    private T[] data;

    // 데이터를 추출할 위치를 알려주는 변수.
    private int front = 0;

    // 데이터를 삽입할 위치를 알려주는 변수.
    private int rear = 0;

    // 큐의 기본 크기 상수 - 큐를 생성할 때 크기를 지정하지 않은 경우에 사용.
    private const int defaultCapacity = 100;

    // 큐의 저장소 크기.
    private int capacity = 0;

    // 큐에 저장된 요소의 수.
    private int size = 0;
    // 공개 프로퍼티.
    // 큐에 저장된 요소의 수 반환.
    public int Size { get { return size; } }

    // 큐가 비었는지 확인하는 프로퍼티.
    // front와 rear가 같은 위치를 가리키는 경우는 큐가 빈 상태.
    public bool IsEmpty { get { return front == rear; } }

    // 큐가 가득 차 있는지 확인하는 프로퍼티.
    // rear와 front가 1개 차이인 경우 큐가 가득 차 있는 상태.
    public bool IsFull { get { return ((rear + 1) % capacity) == front; } }

    // 객체 생성 - 생성자.
    public Queue(int capacity = 0)
    {
        this.capacity = capacity;

        // 큐 저장소의 크기 초기화.
        this.capacity = this.capacity == 0 ? defaultCapacity : this.capacity;

        // 나머지 변수들 초기화.
        data = new T[capacity];
        size = 0;
        front = 0;
        rear = 0;
    }

    // 데이터 삽입 - Enqueue.
    public bool Enqueue(T value)
    {
        // 예외 처리.
        if (IsFull)
        {
            Console.WriteLine("오류: 큐가 가득차 있어 데이터 추가가 불가능합니다.");
            return false;
        }

        // 데이터를 삽입할 다음 위치를 구한 뒤에 데이터 삽입.
        rear = (rear + 1) % capacity;
        data[rear] = value;

        return true;
    }

    // 데이터 추출 - Dequeue.
    public bool Dequeue(out T value)
    {
        // 예외 처리.
        if (IsEmpty)
        {
            Console.WriteLine("오류: 큐가 비어 있어 추출할 데이터가 없습니다.");
            value = default(T);
            return false;
        }

        // 데이터 추출할 위치를 구한 뒤 데이터 추출.
        front = (front + 1) % capacity;
        value = data[front];
        data[front] = default(T);
        size--;
        return true;
    }

    // 데이터 출력 함수.
    public void Print()
    {
        // 예외 처리.
        if (IsEmpty)
        {
            Console.WriteLine("오류: 큐가 비어 있어 출력할 데이터가 없습니다.");
            return;
        }

        // 큐를 순회하면서 데이터 출력.
        int max = (front < rear) ? rear : rear + capacity;
        for (int ix = front + 1; ix <= max; ++ix)
        {
            Console.Write($"{data[ix % capacity]} ");
        }

        Console.WriteLine();
    }
}
