using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Location2D
{
    // 행 (가로 좌표).
    public int X {  get; private set; }
    //열 (세로 좌표).
    public int Y { get; private set; }

    // 생성자.
    public Location2D(int row = 0, int column = 0)
    {
        X = row;
        Y = column;
    }


}

