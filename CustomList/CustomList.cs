using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
// 동적 배열을 구현하는 클래스.
// Dynamic Array
public class CustomList<T> : IEnumerator
{
    public object Current { get {  return current; } }

    private T[] data;
    private int size = 0;       // 리스트의 크기를 추적해서 저장할 변수.
    private int capacity = 2;   // 리스트가 현재의 크기에서 저장할 수 있는 실제 크기. 동적 배열의 비밀은 여기에 있다. 다수가 2로 하는데 4로 설정하는 경우도 있다. 이렇게 하면 데이터라는 저장 자리가 2개가 확보된다. 0 인덱스와 1 인덱스로. 처음 상태로 출력하면 사이즈가 0칸이라고 나온다. 실제로는 2 칸 넣을 수 있음에도. add로 1개만 넣으면 사이즈가 1칸이라고 나온다. 거기에 하나 더 넣으면 이제 사이즈가 2 칸이 나온다. 사이즈가 캐퍼시티와 같아지면 확장하게 만든다. 그러면 캐퍼시티는 4가 되고, 사이즈는 3칸이 나온다. 그렇게 또 넘기면 더 확보하고 기존 데이터를 옮겨오고 입력받은 값을 저장한다. 이걸 반복하는 것이다. 성능에서 유일하게 안 좋을 때는 크기가 변할 때다. 그런데 크기가 변할 때는 처음에 자료 세팅할 때 정도 외에는 거의 없다. 배열의 장점은 얻었지만, 크기가 바뀔 때는 메모리에서 이사를 다녀야 해서 그 때만 성능이 떨어진다. 그래서 자료구조에 사이즈가 자주 변할 일이 없다면 리스트를 사용하면 된다. 왜냐하면 안 변할 때는 어레이와 거의 성능 차가 없으니까. C#에서 Count가~. 확장할 때 얼마나 확장해줄지도 우리가 정해야 한다.2배씩 올라가면 데이터 삽입 횟수가 올라가면 이사 횟수가 줄어서 좋다. 하지만 데이터 삽입이 빈번하지 않으면, 남은 공간이 낭비되는 기간이 길어지게 된다. 1.5배와 2배 중에 골라서 쓰는데 대부분 2배를 고른다.
    
    // GetEnumerator 구현에 필요한 변수.
    private int index = 0;
    private T current;

    // 생성자가 필요하다. 문자열이 이런 방식을 활용해서 저장하고 불러온다.
    public CustomList() 
    { 
        // 내부 저장소 초기화(생성).
        data = new T[capacity]; //일단 저장소를 2칸 만들어둔다.
        size = 0; //사이즈를 0으로 초기화해준다.(변수에서 지정하고 있긴 하지만.)
    }
    // 인덱서가 필요하다. 배열처럼 접근할 수 있도록.
    // 내부 저장소의 값을 읽어서 반환하거나, 값을 설정할 때 사용.
    public T this[int index]
    {
        get
        {
            //여기도 위험하다. 인덱스의 범위가 배열의 크기를 넘어가면 안 되는데 그냥 접근시켜버리고 있다. 가능하다면 앞뒤로 오류가 나지 않도록 범위 검증을 하고 사용자에게 오류 메시지를 보여주는 것이 적절할 것이다. 마이너스로도 플러스로도 넘쳐선 안 된다.
            return data[index];
        }
        set
        {
            // 위험하다.
            data[index] = value;
        }
    }
    // 데이터 추가.
    public void Add(T newValue)
    {
    // 크기가 변해야 하는지 확인하고, 필요하면 이사.
    if (size == capacity)
        {
            // 새로운 곳을 확보하기.
            ReAlliocate(capacity * 2);
        }

        //데이터를 저장할 지점에 새로운 값을 저장한다.
        data[size] = newValue;

        //저장소의 크기를 하나 늘린다.
        size++;
    }

    // 데이터 저장 공간을 변경하는 메소드
    private void ReAlliocate(int newCapacity)
    {
        // 큰 저장공간 확보.
        T[] newData = new T[newCapacity];
        //기존 데이터를 새로운 위치로 옮기기ㅏ.
        //C#에서 제공하는 기능. C++에 있는 MemCopy를 이용한 것. C#은 MemCopy를 직접 호출하지 못하게 막아두었다. 호출 방법은 Array.Copy(Array sourceArray, Array destinationArray, int length);
        for (int ix = 0; ix < size; ++ix)
        {
            newData[ix] = data[ix];
        }

        // 내부 저장소를 새로운 위치로 옮김.
        data = newData;
        // capacity 값 업데이트. 이것이 이 자료구조의 핵심 구조.
        capacity = newCapacity;
    }
    
    // 데이터 삭제1 - 삭제할 데이터 값을 전달해서 삭제.
    public bool Remove(T deleteValue)
    {
        //저장된 값이 없으면 삭제 실패.
        if (size == 0)
        {
            return false;
        }
        // 검색 시작.
        int targetIndex = -1;//오류를 명확하게 하기 위해서 일부러 넣으면 안 되는 값을 넣는다.
        for (int ix = 0; ix < size; ++ix)
        {
            //내부 저장소에서 삭제하려는 값과 비교해 검색을 진행.
            if (data[ix].Equals(deleteValue) == true)
            {
                targetIndex = ix;
                break;
            }
        }
        //검색 여부를 확인하고, 찾았으면 해당 데이터 삭제.
        if (targetIndex >= 0)
        {
            // 인덱스를 기반으로 데이터 삭제.(2번과 같은 기능이라서 호출시킬 것.)
            RemoveAt(targetIndex);
            return true;
        }
        return false;
    }
    // 데이터 삭제2 - 삭제할 위치를 인덱스로 전달해서 삭제. 이 부분이 삭제에서 핵심.
    public bool RemoveAt(int index)
    {
        //사이즈가 0이거나 삭제할 위치가 사이즈를 벗어날 경우.
        if (size == 0 || index < 0 || index >= size)
        {
            return false;
        }
        // 삭제할 값을 검색해서 없애고 정렬해야 한다. 삭제한 위치가 비어있지 않도록 다음 칸들을 한 칸씩 당겨오도록.
        int listIndex = 0;
        for (int ix = 0; ix < size; ++ix)
        {
            // 삭제하려는 인덱스라면 복사를 하지 않고 건너뜀.
            if (ix == index)
            { 
                continue;
            }
            data[listIndex] = data[ix];
            listIndex++; //data[listIndex++]에서 ++를 안에 써놓고 싶지 않은 경우.
        }
        data[size - 1] = default(T); //C#은 값타입과 참조 타입으로 나뉘는데, 참조의 경우에는 기본 값이 null이다. 근데 null과 0을 우리가 어느 하나 지정해서 넣어줄 수 없다. 그래서 c#에게 기본 값을 알아서 넣어달라고 하는 것이다. C++는 0 넣으면 참조일 경우에 null로 읽혀서 상관이 없다.
        size--;
        return true;
    }

    // 리스트에서 다음 위치에 있는 요소가 있으면 true를 반환하고,
    // 없으면 false를 반환하면서 current 변수에 현재 위치의 요소를 설정하는 함수.
    public bool MoveNext()
    {
        if (index  < size)
        {
            // 현재 위치의 요소를 할당.
            current = data[index];

            // 다음 위치를 가리키기 위해 인덱스 증가.
            index++;

            // 다음으로 이동이 가능하다고 true 반환.
            return true; 
        }
        return false;
    }

    // Ienumerator 초기화.
    public void Reset()
    {
        index = 0;
        current = default(T);
    }

    // foreach에서 무브 넥스트 하고 커런트를 읽는 식으로 반복한다. 

    public IEnumerator GetEnumerator()
    {
        Reset();
        return this;
    }

    // 길이 확인.
    public int Count
    {
        get 
        {
            return size; 
        }
    }

}
