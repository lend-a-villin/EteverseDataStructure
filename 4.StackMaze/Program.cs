// 진입점을 제공하는 프로그램 클래스.
using System.Data;
using System.Diagnostics;

class Program
{
    // 부가적인 내용. 미로의 이동 경로를 출력할 때 사용할 메소드.
    static void PrintLocation(Maze maze, int xPos, int yPos, int delay)
    {
        // CPU재우기. 이걸 안 하면 이동이 너무 빠르다.
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
        Maze maze = new Maze();
    
        // 시작지점 저장용 변수 선언.
        Location2D startLocation = new Location2D();

        // 시작 지점 검색
        for (int y = 0; y < maze.GetSize(); ++y)
        {
            for (int x = 0; x < maze.GetSize(); ++x)
            {
                // 시작 지점 검색 후 저장.
                if (maze[x,y] == 'e')
                {
                    startLocation = new Location2D(x,y);
                    break;
                }
            }
        }

        // 탐색 시작.
        // 시작 위치를 스택에 삽입.
        MazeStack<Location2D> stack = new MazeStack<Location2D>();
        stack.Push(startLocation);

        int count = 0;
        while (stack.IsEmpthy == false)
        {
            if (stack.Pop(out Location2D currentLocation))
            {
                //현재 위치 탐색.
                //Console.Write($"({currentLocation.X},{currentLocation.Y} )");
                PrintLocation(maze, currentLocation.X, currentLocation.Y, 500);
                count++;
                //가로 10칸 출력한 후 엔터 코드 입력.
                //if (count % 10 == 0)
                //{
                //    Console.WriteLine();
                //}
                // 이동한 위치가 탈출지점인지 비교(미로 탈출 성공).
                if (maze[currentLocation.X, currentLocation.Y] == 'x')
                {
                    maze[currentLocation.X, currentLocation.Y] = 'P';

                    Console.WriteLine("\n\n미로 탐색 성공");
                    //이동 경로 출력.
                    maze.Print();
                    Console.ReadKey();
                    
                    // 프로그램 종료.
                    return;
                }
                // 이동한 위치가 출구가 아니라면, 탐색한 위치를 방문했다고 표기(이동 가능한 위치로 인식하지 않도록).
                maze[currentLocation.X, currentLocation.Y] = '.';

                // 상/하/좌/우 위치 중 이동 가능한 위치를 스택에 삽입.
                //스택이라서 반대 순서로 진행한다.
                //상.
                if (maze.IsValidLocation(currentLocation.X, currentLocation.Y - 1))
                {
                    stack.Push(new Location2D(currentLocation.X, currentLocation.Y - 1));
                }
                //하.
                if (maze.IsValidLocation(currentLocation.X, currentLocation.Y + 1))
                {
                    stack.Push(new Location2D(currentLocation.X, currentLocation.Y + 1));
                }

                // 좌.
                if (maze.IsValidLocation(currentLocation.X - 1, currentLocation.Y))
                {
                    stack.Push(new Location2D(currentLocation.X - 1, currentLocation.Y));
                }
                
                //우.
                if (maze.IsValidLocation(currentLocation.X + 1, currentLocation.Y))
                {
                    stack.Push(new Location2D(currentLocation.X + 1, currentLocation.Y));
                }

            }
        }
        Console.WriteLine("\n미로 탐색 실패.");

        Console.ReadKey();
    }
}