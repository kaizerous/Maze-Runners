using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Mazz
{
    public class GridNode
    {
        public static int NodeSize = MazGen.NodeWidth;
        public static int NodePadding = 5;
        public int[] NodeWalls = new int[4] { 1, 1, 1, 1 };
        public int Row, Column;

        private static long _Seed = DateTime.Now.Ticks;
        public static Random _Random = new Random((int)_Seed);

        public GridNode() { }

        public bool AllWallsUp()
        {
            for (int i = 0; i < 4; i++)
                if (NodeWalls[i] == 0) return false;

            return true;
        }

        public void RemoveWall(int Wall)
        {
            NodeWalls[Wall] = 0;
        }

        public void RemoveWall(GridNode Node)
        {
            int _RemovedWall = GetAdjacentWall(Node);
            NodeWalls[_RemovedWall] = 0;
            int _OppositeWall = (_RemovedWall + 2) % 4;
            Node.NodeWalls[_OppositeWall] = 0;
        }

        public int GetAdjacentWall(GridNode Node)
        {
            if (Node.Row == Row)
            {
                if (Node.Column < Column) return 0;
                else return 2;
            }
            else
            {
                if (Node.Row < Row) return 1;
                else return 3;
            }
        }

        public int GetRandomWall()
        {
            int _NextWall = _Random.Next(0, 3);
            while ((NodeWalls[_NextWall] == 0) ||
                ((Row == 0) && (_NextWall == 0)) ||
                ((Row == MazGen.Rows - 1) && (_NextWall == 2)) ||
                ((Column == 0) && (_NextWall == 1)) ||
                ((Column == MazGen.Columns - 1) && (_NextWall == 3)))
            {
                _NextWall = _Random.Next(0, 3);
            }
            return _NextWall;
        }

        public void Draw(Graphics _Graphics)
        {

            for (int i = 2; i <= 3; i++)
            {
                if (NodeWalls[i] == 1)
                    _Graphics.DrawLine(Pens.Blue,
                        i == 3 ? (Row + 1) * NodeSize + NodePadding : Row * NodeSize + NodePadding,
                        i == 2 ? (Column + 1) * NodeSize + NodePadding : Column * NodeSize + NodePadding,
                        (Row + 1) * NodeSize + NodePadding,
                        (Column + 1) * NodeSize + NodePadding);
            }
        }
    }
}
