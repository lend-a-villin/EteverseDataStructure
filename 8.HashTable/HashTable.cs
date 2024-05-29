using System;
using System.ComponentModel.Design;

// 키 값을 사용해서 데이터를 저장하고 관리하는 해시테이블 클래스.
public class HashTable<TKey, TValue>
{
    // 필드.
    // 버킷 카운트 소수(Prime Number)로 하는 것이 유리함.
    private const int bucketCount = 19;

    // 저장소 - 링크드 리스트의 배열 -> 충돌을 해결하기 위해 체이닝 방식을 사용함.
    private LinkedList<Pair<TKey, TValue>>[] table;

    // 메시지 (공개 메소드) - 인터페이스.

    // 생성 - 생성자.
    public HashTable() 
    {
        // 배열 생성.
        table = new LinkedList<Pair<TKey, TValue>>[bucketCount];

        // 배열 내부의 링크드리스트 객체 생성.
        for (int ix = 0; ix < bucketCount; ++ix)
        {
            table[ix] = new LinkedList<Pair<TKey, TValue>>();
        }
    }
    // 데이터 추가.
    public void Add(TKey key, TValue value)
    {
        // 저장할 배열의 위치 결정 - 이때 해시 함수를 쓴다.
        int bucketIndex = GenerateHash(key) % bucketCount;

        // 저장할 위치에 이미 같은 데이터가 있지 않은지 검증.

        // 데이터 불러오기.
        LinkedList<Pair<TKey, TValue>> list = table[bucketIndex];

        // 데이터가 있는지 확인.
        foreach (LinkedList<Pair<TKey, TValue>>.Node node in list)
        {
            if (node.Data.Key.Equals(key))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("오류: 이미 동일한 데이터가 저장되어 있습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
        }

        // 문제가 없다면, 링크드 리스트에 추가.
        list.AddToLast(new Pair<TKey, TValue>(key, value));
    }
    // 데이터 삭제.
    public bool Delete(TKey key)
    {
        // 데이터가 저장된 배열의 위치 계산.
        int bucketIndex = GenerateHash(key) % bucketCount;

        // 데이터가 저장된 위치의 링크드리스트 가져오기.
        var list = table[bucketIndex];

        // 검색.
        // 여기선 var를 쓰면 안 된다. 형 변환을 명확하게 하라고 지정해줘야 한다.
        foreach (LinkedList<Pair<TKey, TValue>>.Node node in list)
        {
            // 삭제하려는 키를 가진 데이터가 있는지 확인 후 있으면 삭제.
            if (node.Data.Key.Equals(key))
            {
                list.DeleteNode(node.Data);
                Console.WriteLine($"키: {key} 항목이 삭제되었습니다.");
                return true;
            }
        }

        // 못 찾으면 실패.
        Console.ForegroundColor= ConsoleColor.Red;
        Console.WriteLine("오류: 삭제할 데이터를 찾지 못했습니다.");
        Console.ForegroundColor= ConsoleColor.White;
        return false;
    }


    // 검색 1- 키로 검색 후 Value를 출력하는 함수.
    public bool Find(TKey key, out TValue outValue)
    {
        // 데이터가 저장된 배열의 위치 계산.
        int bucketIndex = GenerateHash(key) % bucketCount;

        // 데이터가 저장된 위치의 링크드리스트 가져오기.
        var list = table[bucketIndex];

        // 리스트가 비어 있으면 검색이 필요하지 않음.
        if (list.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("오류: 해당 데이터를 찾지 못했습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            outValue = default(TValue);
            return false;
        }
        // 여기선 var를 쓰면 안 된다. 형 변환을 명확하게 하라고 지정해줘야 한다.
        foreach (LinkedList<Pair<TKey, TValue>>.Node node in list)
        {
            // 검색하려는 키를 가진 데이터가 있는지 확인 후 있으면 값 돌려주기.
            if (node.Data.Key.Equals(key))
            {
                outValue = node.Data.Value;
                return true;
            }
        }

        // 못 찾으면 실패.
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("오류: 해당 데이터를 찾지 못했습니다.");
        Console.ForegroundColor = ConsoleColor.White;
        outValue = default(TValue);
        return false;
    }

    // 검색 2- 키로 검색 후 Pair<Key, Value>를 출력해주는 함수.
    public bool Find(TKey key, out Pair<TKey, TValue> outValue)
    {
        // 데이터가 저장된 배열의 위치 계산.
        int bucketIndex = GenerateHash(key) % bucketCount;

        // 데이터가 저장된 위치의 링크드리스트 가져오기.
        var list = table[bucketIndex];

        // 리스트가 비어 있으면 검색이 필요하지 않음.
        if (list.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("오류: 해당 데이터를 찾지 못했습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            outValue = default(Pair<TKey, TValue>);
            return false;
        }
        // 여기선 var를 쓰면 안 된다. 형 변환을 명확하게 하라고 지정해줘야 한다.
        foreach (LinkedList<Pair<TKey, TValue>>.Node node in list)
        {
            // 검색하려는 키를 가진 데이터가 있는지 확인 후 있으면 값 돌려주기.
            if (node.Data.Key.Equals(key))
            {
                outValue = node.Data;
                return true;
            }
        }

        // 못 찾으면 실패.
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("오류: 해당 데이터를 찾지 못했습니다.");
        Console.ForegroundColor = ConsoleColor.White;
        outValue = default(Pair<TKey, TValue>);
        return false;
    }

    // 출력.
    public void Print()
    {
        // 테이블 배열을 순회.
        foreach (var list in table)
        {
            // 건너뛰기 - 링크드리스트에 저장된 요소가 없으면 루프 건너뜀.
            // 컨티뉴나 브레이크 들어갈 수 있는 알고리즘에 이것들을 잘 써주면 성능 개선의 여지가 높다.
            if (list .Count == 0)
            {
                continue;
            }
            // 링크드리스트를 순회하면서 데이터 출력.
            foreach(LinkedList<Pair<TKey, TValue>>.Node node in list)
            {
                Console.WriteLine($"키: {node.Data.Key}, 값: {node.Data.Value}");
            }
        }
    }


    // 메소드 - 해시 함수(해시를 생성하는 함수).
    private int GenerateHash(TKey key)
    {
        // 생성할 해시를 저장할 변수.
        int hash = 0;
        // 문자 배열.
        char[] chars = key.ToString().ToCharArray();
        for (int ix = 0; ix < chars.Length; ++ix)
        {
            // 해시 생성 알고리즘.
            hash = hash * 31 + chars[ix];
        }
        // 양수로 만들어서 반환.
        return Math.Abs(hash);
    }
}
