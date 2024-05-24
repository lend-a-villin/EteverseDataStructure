using System;
class Warmup
{
    static void Main()
    {

        while (true)
        {
            char changeChar = '0';
            while (true)
            {
                string readLine = Console.ReadLine();
                changeChar = readLine[0];

                changeChar = readLine[0];
                ToLower(changeChar);
                ToUpper(changeChar);    
                break;
            }
        }
    }

    // 대문자를 소문자로 바꾸는 함수.
    static char ToLower(char upperCase)
    {
        if ((int)upperCase <= 96 || (int)upperCase >= 123) 
        {
            Console.WriteLine("소문자가 아닙니다. 다시 입력하세요.");
        }
        else
        {
            Console.WriteLine($"입력하신 문자의 소문자는 {(char)((int)upperCase - 32)}입니다.");
        }
        return upperCase;
    }

    // 소문자를 대문자로 바꿔주는 함수.
    static char ToUpper(char lowerCase)
    {
        if ((int)lowerCase <= 64 || (int)lowerCase >= 91)
        {
            Console.WriteLine("대문자가 아닙니다. 다시 입력하세요.");
        }
        else
        {
            Console.WriteLine($"입력하신 문자의 대문자는 {(char)((int)lowerCase + 32)}입니다.");
        }
        return lowerCase;
    }

}