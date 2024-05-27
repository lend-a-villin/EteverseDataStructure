using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 유저의 경험치를 저장할 때 사용하는 스택 저장소.
// 공개 메소드를 통해서 다른 객체와 소통하고, 객체의 상태는 감춘다.
// UML을 공부하지 않더라도 공개해야 할 기능이 무엇인지부터 생각해보고 코드를 짜면 꽤나 깔끔하게 짤 수 있다.
// 우리가 지금 이렇게 배우는 건 코딩 테스트 통과하기 위함. 원칙적으로 좋은 공부는 스스로 고민해보는 것. 하지만 우리는 시간이 없어서 이렇게 한다.
    internal class ExpStack
{
    // 필드.(필드는 감추기).
    // 현재 스택에 저장된 요소의 수.
    private int count = 0;

    // 스택에 저장할 수 있는 최대 개수.
    private const int maxCapacity = 100;

    // 스택에서 사용할 데이터 저장 공간.
    private float[] data;

    // 스택이 가득 찼는지를 알려주는 메소드/프로퍼티 (IsFull).
    // 스택에 현재 저장된 요소의 수가 스택이 저장할 수 있는 크기와 같은지를 비교.
    // List인 경우에는 가득차면 확장될 것이기 때문에 의미가 없다.
    public bool IsFull { get {return count == maxCapacity; } }

    // 스택이 비었는지를 알려주는 메소드/프로퍼티 (IsEmthy).
    // count 값이 0인지 확인.
    public bool IsEmpthy { get { return count == 0; } }


    // 스택에 저장된 요소의 수를 알려주는 메소드/프로퍼티 (Count).
    public int Count { get { return count; } }

    // 메시지 (공개 메소드).
    // 객체 생성.
    public ExpStack() 
    { 
        // 초기화 - Initialization = Initialize = (Init).
        count = 0;
        data = new float[maxCapacity];
    }

    // 스택에 새로운 자료를 저장하는 메소드 (Push).
    public bool Push(float item)
    {
        if (IsFull)
        {
            Console.WriteLine("오류 : 스택이 가득 찼기 때문에 데이터를 추가할 수 없습니다.");
            return false;
        }

        // 데이터 추가.
        data[count] = item;
        count++;

        // 데이터 추가 성공 반환.
        return true;
    }
    // 스택에 저장된 요소 중 가장 위에 있는 요소를 반환하는 메소드 (Pop).
    // out이라는 키워드가 있고, ref가 있다.
    // out은 함수 안에서 강제로 초기화를 해야 하며, ref는 함수 밖에서 강제로 초기화해야 한다.
    public bool Pop(out float outValue)
    {
        // 검사 - 스택이 비어 있지 않은지 확인이 필요함.
        if (IsEmpthy)
        {
            // 오류 메시지.
            Console.WriteLine("오류: 스택이 비어 있어 반환할 값이 없습니다.");
            // C#의 out 키워드로 전달된 변수는 함수에서 꼭 값을 할당해야 함.
            outValue = 0f;
            // 데이터 반환 실패.
            return false;
        }
        // 반환할 데이터를 설정 후 count 감소 처리.
        count--;
        outValue = data[count];
        data[count] = 0f;
        // 데이터 반환 처리 성공.
        return true;
    }
}
