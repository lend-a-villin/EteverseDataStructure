using System;
using System.Drawing;
namespace Space
{
    //직접 구현해보는 배열 클래스.
    public class Array
    {
        // 자료 저장 공간(space, container, collection)
        private int[] data;
        // 기본 배열의 크기 값.
        private const int defaultLength = 5;

        // 생성자.
        public Array(int size)
        {
            data = size == 0 ? new int[defaultLength] : new int[size];
            //아래의 코드와 동일하다.
            //if (size == 0)
            //{
            //    data = new int[defaultLength];
            //}
            //else
            //{
            //    data = new int[size];
            //}
        }

        // 접근 메소드.
        public int At(int index)
        {
            return data[index];
        }

        // 데이터 설정 메소드.
        public void SetData(int index, int value)
        {
            data[index] = value;
        }

        // 배열의 크기 반환 메소드

        public int GetSize()
        {
            return data.Length;
        }

        public int Length { get { return data.Length; } }
    }
}