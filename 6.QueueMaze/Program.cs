using System;
using System.Threading;

public class Program
{
    static void PrintLocation(Maze maze, int xPos, int yPos, int delay)
    {
        // 재우기.
        Thread.Sleep(delay);

        // 커서 안보이도록 설정 (화면이 깜박거리지 않도록 하기 위해).
        Console.CursorVisible = false;

        // 콘솔의 커서 위치를 초기화.
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < maze.GetSize(); ++y)
        {
            for (int x = 0; x < maze.GetSize(); ++x)
            {
                // 플레이어 위치 출력.
                if (x == xPos && y == yPos)
                {
                    // 플레이어 색상 설정.
                    Console.ForegroundColor = ConsoleColor.Green;

                    // 플레이어 위치 출력.
                    Console.Write("P ");

                    // 색상 초기화.
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                // 지나온 길은 빨간색으로 표시.
                if (maze[x, y] == '.')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write($"{maze[x, y]} ");

                // 색상 초기화.
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        // 맵 객체 생성.
        Maze maze = new Maze();

        // 시작 지점을 저장하기 위한 변수 선언.
        Location2D startLocation = new Location2D();

        // 미로 출력 및 시작 지점 검색.
        for (int y = 0; y < maze.GetSize(); ++y)
        {
            for (int x = 0; x < maze.GetSize(); ++x)
            {
                Console.Write($"{maze[x, y]} ");

                // 시작 지점인 경우 저장.
                if (maze[x, y] == 'e')
                {
                    startLocation = new Location2D(x, y);
                }
            }

            Console.WriteLine();
        }

        // 시작 지점을 스택에 삽입.
        Queue<Location2D> locationQueue = new Queue<Location2D>(maze.GetSize());
        locationQueue.Enqueue(startLocation);

        // 미로 탐색.
        int count = 0;
        while (locationQueue.IsEmpty == false)
        {
            // 현재 위치 반환.
            Location2D currentLocation = new Location2D();
            locationQueue.Dequeue(out currentLocation);

            // 현재 탐색한 위치 출력.
            //Console.Write($"({currentLocation.X},{currentLocation.Y}) ");

            PrintLocation(maze, currentLocation.X, currentLocation.Y, 500);

            // 가로 10칸 출력했을 때 다음 칸에 출력하기 위한 코드.
            count++;
            if (count == 10)
            {
                count = 0;
                Console.WriteLine();
            }

            // 출구에 도착했으면, 탐색 성공.
            if (maze[currentLocation.X, currentLocation.Y] == 'x')
            {
                Console.WriteLine("\n\n미로 탐색 성공");
                Console.ReadKey();

                // 프로그램 종료.
                return;
            }

            // 출구가 아닌 경우에는, 탐색한 위치를 방문한 위치로 표시.
            maze[currentLocation.X, currentLocation.Y] = '.';

            // 상/하/좌/우 위치 중 이동 가능한 위치는 스택에 삽입.
            if (maze.IsValidLocation(currentLocation.X, currentLocation.Y - 1) == true)
            {
                locationQueue.Enqueue(new Location2D(currentLocation.X, currentLocation.Y - 1));
            }
            if (maze.IsValidLocation(currentLocation.X, currentLocation.Y + 1) == true)
            {
                locationQueue.Enqueue(new Location2D(currentLocation.X, currentLocation.Y + 1));
            }
            if (maze.IsValidLocation(currentLocation.X - 1, currentLocation.Y) == true)
            {
                locationQueue.Enqueue(new Location2D(currentLocation.X - 1, currentLocation.Y));
            }
            if (maze.IsValidLocation(currentLocation.X + 1, currentLocation.Y) == true)
            {
                locationQueue.Enqueue(new Location2D(currentLocation.X + 1, currentLocation.Y));
            }
        }

        Console.WriteLine("\n미로 탐색 실패.");

        Console.ReadKey();
    }
}