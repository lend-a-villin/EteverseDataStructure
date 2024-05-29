using System;
// 키 값을 쌍으로 데이터를 저장할 때 사용할 pair 클래스.
public class Pair<TKey, TValue>
{
    // 키를 나타내는 변수.
    private TKey key;
    // 값(Value)를 나타내는 변수.
    private TValue value;

    // Getter.
    public TKey Key { get { return key; } }
    public TValue Value { get { return value; } }

    // 생성자에 기본 값 설정.
    public Pair()
    {
        key = default(TKey);
        value = default(TValue);
    }

    // 생성자에 값 전달 후 적용.
    public Pair(TKey key, TValue value)
    {
        this.key = key;
        this.value = value;
    }
}
