using System;

// 미로 정보를 저장하는 클래스.
public class Maze
{
    // 필드.
    private char[,] maze;

    // 인덱서.
    public char this[int x, int y]
    {
        get
        {
            return maze[x, y];
        }
        set
        {
            maze[x, y] = value;
        }
    }

    // 메시지 (공개 메소드) - 인터페이스.
    public Maze()
    {
        LoadMap("Maze.csv");
    }

    // 이동하려는 위치가 이동 가능한지 판단.
    public bool IsValidLocation(int x, int y)
    {
        // 범위 (예외) 확인.
        if (x < 0 || y < 0 || x >= maze.GetLength(0) || y >= maze.GetLength(0))
        {
            return false;
        }

        // 이동하려는 위치의 문자 값이 0(길)이거나 x(탈출구)인지 확인.
        return maze[x, y] == '0' || maze[x, y] == 'x';
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
                Console.Write($"{maze[x, y]} ");
            }

            Console.WriteLine();
        }
    }

    // 메소드 - 맵 파일을 읽어서 미로 정보로 변환해 저장하는 기능.
    private void LoadMap(string filename)
    {
        // 파일 읽어오기.
        string[] lines = File.ReadAllLines(filename);

        // 미로 배열 객체 초기화.
        maze = new char[lines.Length, lines.Length];

        // Parser.
        // 라인 별로 루프를 순회하면서 맵 데이터 파싱(Parse/Parsing-해석).
        for (int y = 0; y < lines.Length; ++y)
        {
            // 콤마(,)를 기준으로 맵 정보를 해석(파싱).
            string[] row = lines[y].Split(',');
            for (int x = 0; x < row.Length; ++x)
            {
                maze[x, y] = row[x][0];
            }
        }
    }
}