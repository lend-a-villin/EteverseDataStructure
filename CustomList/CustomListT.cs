using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 강사님 작성 데이터.

public class CustomListT<T>
{
    // 내부 저장소.
    private T[] data;
    private int size = 0;           // 리스트의 크기를 추적해 저장할 변수.
    private int capacity = 2;       // 리스트가 현재의 크기에서 저장할 수 있는 실제 크기.

    public CustomListT()
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
        // 크기가 변해야하는지 확인하고, 필요하면 이사.
        if (size == capacity)
        {
            // 새로운 곳을 확보하고.
            ReAllocate(capacity * 2);
        }

        // 데이터를 저장할 지점에 새로운 값을 저장한다.
        data[size] = newValue;

        // 저장소의 크기를 하나 늘린다.
        size++;
    }

    private void ReAllocate(int newCapacity)
    {
        // 큰 저장공간 확보.
        T[] newData = new T[newCapacity];

        // 기존의 데이터를 새로운 위치로 옮기기.
        for (int ix = 0; ix < size; ++ix)
        {
            newData[ix] = data[ix];
        }

        // 내부 저장소를 새로운 위치로 옮김.
        data = newData;

        // capacity값 업데이트.
        capacity = newCapacity;
    }

    // 데이터 삭제1 - 삭제할 데이터 값을 전달해서 삭제.
    // 전달한 데이터의 삭제를 시도한 후 삭제의 성공 실패 여부를 반환.
    public bool Remove(T deleteValue)
    {
        // 저장된 값이 없으면, 찾을 필요도 없이 삭제 실패.
        if (size == 0)
        {
            return false;
        }

        // 검색 시작.
        int targetIndex = -1;
        for (int ix = 0; ix < size; ++ix)
        {
            // 내부 저장소에서 삭제하려는 값과 비교해 검색을 진행.
            if (data[ix].Equals(deleteValue) == true)
            {
                targetIndex = ix;
                break;
            }
        }

        // 검색 여부를 확인하고, 찾았으면 해당 데이터 삭제.
        if (targetIndex >= 0)
        {
            // 인덱스를 기반으로 데이터 삭제.
            RemoveAt(targetIndex);
            return true;
        }

        return false;
    }

    // 데이터 삭제2 - 삭제할 위치를 인덱스로 전달해서 삭제.
    public bool RemoveAt(int index)
    {
        if (size == 0 || index < 0 || index >= size)
        {
            return false;
        }

        // 정렬.
        int listIndex = 0;
        for (int ix = 0; ix < size; ++ix)
        {
            // 삭제하려는 인덱스라면, 복사를 하지 않고 건너뜀.
            if (ix == index)
            {
                continue;
            }

            data[listIndex] = data[ix];
            listIndex++;
        }

        // 크기 조정 및 데이터 정리.
        data[size] = default(T);
        size--;

        return true;
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
