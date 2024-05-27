using System;
// 미로 정보를 저장하는 클래스.
public class Maze
{
    // 필드.
    private char[,] maze; //이차원 배열은 콤마 하나, 삼차원 비열은 콤마 두 개 넣어주면 된다.

    // 인덱서 여러 파라미터를 받아야 한다면 콤마로 구분하면 된다ㅡ.
    public char this[int row, int column] { get { return maze[row, column]; } set { maze[row, column] = value; } }

    // 메시지 (공개 메소드) - 인터페이스.
    public Maze()
    {
        LoadMap("Maze.csv");
    }
    // 이동하려는 위치가 이동 가능한지 판단.
    public bool IsValidLocation(int row, int column)
    {
        // 범위 (예외) 확인.
        if (row < 0 || column < 0 || row > maze.GetLength(0) || column > maze.GetLength(0))
        {
            return false;
        }
        // 이동하려는 위치의 문자 값이 0(길)이거나 x(탈출구)인지 확인.
        return maze[row, column] == '0' || maze[row, column] == 'x';
    }
    // 미로의 크기를 반환해주는 기능.
    public int GetSize()
    {
        return maze.GetLength(0);
    }
    // 맵 정보 출력하는 기능.
    public void Print()
    {
        // 미로 출력.
        for (int y = 0; y < maze.GetLength(0); ++y)
        {
            for (int x = 0; x < maze.GetLength(1); ++x)
            {

                Console.Write($"{maze[x, y]}");
            }
            Console.WriteLine();
        }
    }

    private void LoadMap(string fileName)
    {
        // 파일 읽어오기.
        string[] lines = File.ReadAllLines(fileName);

        // 미로 객체 배열 초기화. 행과 열이 같기 때문에 지금은 그렇게 읽어도 된다. 
        maze = new char[lines.Length, lines.Length];

        //라인 별로 루프를 순회하면서 맵 데이터 파싱(Parsing/ Parse = 해석). 
        for (int y = 0; y < lines.Length; ++y)
        {
            string[] row = lines[y].Split(',');
            for (int x = 0; x < row.Length; ++x) 
            {
                maze[x, y] = row[x][0]; //x의 첫 번째 문자만 읽어라.
            }
        }
    }
    // 메소드 - 맵 파일을 읽어서 미로 정보로 변환해 저장하는 기능.
     
}
