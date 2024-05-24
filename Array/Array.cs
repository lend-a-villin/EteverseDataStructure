using System;

namespace Container
{
    // 직접 구현해보는 배열 클래스.
    public class Array<T> //<T>를 넣어주면 자료형이 된다. 이때는 아직 뭐로 들어가는지 알 수 없다. 자료형을 다 T로 바꾸면 된다. 그러고 나면 이제 이 클래스는 실체가 없어진다.
    {
        // 필드.

        // 자료 저장 공간(Space, Container, Collection).
        private T[] data; //var은 컴파일 할 때 해석하기 때문에 여기서는 쓸 수 없다. 기능은 다 같은데 여러가지 데이터 타입을 받게 하는 걸 일반화 시킨다고 한다. Generic이라고 한다.

        // 기본 배열의 크기 값.
        private const int defaultLength = 5;

        //인덱서. private T[] data형식으로 불러올 수 있게 해 주는 프로퍼티. C++에서 남용되는 문법을 없애고 보니 필요해서 만들어진 문법이다.
        public T this[int index]
        {
            get
            {
                return data[index]; 
            }
            set
            {
                data[index] = value; //프로퍼티 내부에서 해당 프로퍼티의 값을 설정할 때는 밸류로 받고, 타입도 자동으로 매핑된다. 제네릭이 아닌 프로퍼티도 된다. 
            }
        }

        // 생성자.
        public Array(int size)
        {
            // 전달 받은 size 값을 기준으로 내부 저장소를 생성.
            data = size == 0 ? new T[defaultLength] : new T[size];

            //if (size == 0)
            //{
            //    data = new int[defaultLength];
            //}
            //else
            //{
            //    data = new int[size];
            //}
        }

        // 접근 메소드. array[0];
        public T At(int index)//여기도 T로 바꿔준다.
        {
            return data[index];
        }

        // 데이터 설정 메소드.
        public void SetData(int index, T value) // 밸류도 T로 받는다.
        {
            // 내부 저장소에서 index 위치에 value 값을 설정.
            data[index] = value;
        }

        public int Length
        {
            get
            {
                return data.Length;
            }
        }

        // 배열의 크기 반환 메소드.
        public int GetSize()
        {
            return data.Length;
        }
    }
}